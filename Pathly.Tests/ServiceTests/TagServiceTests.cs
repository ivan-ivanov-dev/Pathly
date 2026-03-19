using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Implementation;
using Pathly.Services.Mappings;
using Pathly.ViewModels.Tags;
namespace Pathly.Tests;

[TestFixture]
public class TagServiceTests
{
    private ApplicationDbContext _context;
    private IMapper _mapper;
    private TagService _tagService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        _context = new ApplicationDbContext(options);
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();

        _tagService = new TagService(_mapper,_context);
    }

    [TearDown]
    public void TearDown()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    [Test]
    public async Task CreateTagAsync_ShouldAddTag_WhenValid()
    {
        await _tagService.CreateTagAsync("Work", "user1");

        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == "Work");
        Assert.That(tag, Is.Not.Null);
        Assert.That(tag.UserId, Is.EqualTo("user1"));
    }

}
