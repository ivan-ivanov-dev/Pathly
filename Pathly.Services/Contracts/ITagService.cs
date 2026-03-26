using Pathly.DataModels;
using Pathly.ViewModels.Tags;

namespace Pathly.Services.Contracts
{
    public interface ITagService
    {
        public Task<IEnumerable<TagViewModel>> GetUserTagsAsync(string userId, string searchString = null); 
        public Task CreateTagAsync(string name, string userId); 
        public Task<bool> DeleteTagAsync(int id, string userId);
    }
}
