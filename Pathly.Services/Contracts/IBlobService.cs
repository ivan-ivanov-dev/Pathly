using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Contracts
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(IFormFile file);
        string GetReadOnlyLink(string blobName);
    }
}
