using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Tags;

namespace Pathly.Services.Implementation
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;
        public TagService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateTagAsync(string name, string userId)
        {
            var normalizedName = name.Trim().ToLower();

            //Case-insensitive
            bool tagExists = await _context.Tags.AnyAsync(t => t.UserId == userId && t.Name.ToLower() == normalizedName); 

            if(tagExists)
            {
                throw new InvalidOperationException("A tag with the same name already exists!");
            }
            var tag = new Tag
            {
                Name = name.Trim(),
                UserId = userId
            };

            _context.Tags.Add(tag); 
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTagAsync(int id, string userId)
        {
            var tag = await _context.Tags.FindAsync(id); 
            if(tag == null)
            {
                return false;
            }
            if(tag.UserId != userId)
            {
                throw new UnauthorizedAccessException(); 
            }
            
            _context.Tags.Remove(tag); 
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<TagViewModel>> GetUserTagsAsync(string userId)
        {
            return await _context.Tags
            .Where(t => t.UserId == userId)
            .OrderBy(t => t.Name)
            .ProjectTo<TagViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}
