using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Implementation;
using AutoMapper;
using Pathly.ViewModels.Tags;
namespace Pathly.Tests;

[TestFixture]
public class TagServiceTests
{
    private ApplicationDbContext _context;
    private Mock<IMapper> _mapperMock;
    private TagService _tagService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        _context = new ApplicationDbContext(options);
        _mapperMock = new Mock<IMapper>();

        // 2. Инициализираме сървиса
        _tagService = new TagService(_mapperMock.Object,_context);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }
}
