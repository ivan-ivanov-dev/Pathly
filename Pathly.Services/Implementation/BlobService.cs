using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Implementation
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly AzureStorageSettings _storageSettings;
        private readonly ApplicationDbContext _context; 
        private readonly string _containerName;

        public BlobService(IConfiguration configuration, IOptions<AzureStorageSettings> storageSettings,ApplicationDbContext context)
        {
            _storageSettings = storageSettings.Value;
            _blobServiceClient = new BlobServiceClient(_storageSettings.ConnectionString);
            _containerName = configuration[_storageSettings.ContainerName];
            _context = context;
        }

        public async Task<bool> AddResourceAsync(int actionId, string blobName)
        {
            var milestone = await _context.Actions.FindAsync(actionId);
            if (milestone == null)
            {
                return false;
            }

            milestone.Resources = string.IsNullOrEmpty(milestone.Resources)
                ? blobName
                : milestone.Resources + ";" + blobName;

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteBlobAsync(string blobName)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                return false;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            // Deletes the file and returns true if successfull, otherwise false
            return await blobClient.DeleteIfExistsAsync();
        }

        public string GetReadOnlyLink(string blobName)
        {
            if (string.IsNullOrEmpty(blobName))
            {
                return null;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            // Generate a SAS token for read-only access - valid for 1h
            if (blobClient.CanGenerateSasUri)
            {
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = _containerName,
                    BlobName = blobName,
                    Resource = "b",
                    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
                };
                sasBuilder.SetPermissions(BlobSasPermissions.Read);

                return blobClient.GenerateSasUri(sasBuilder).ToString();
            }
            return null;
        }

        public async Task<bool> RemoveResourceAsync(int actionId, string blobName)
        {
            var milestone = await _context.Actions.FindAsync(actionId);
            if (milestone == null || string.IsNullOrEmpty(milestone.Resources))
            {
                return false;
            }

            var resources = milestone.Resources.Split(';').ToList();
            if (resources.Remove(blobName))
            {
                milestone.Resources = string.Join(";", resources);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            string blobName = $"{Guid.NewGuid()}_{file.FileName}";
            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);

            return blobName;
        }
    }
}
