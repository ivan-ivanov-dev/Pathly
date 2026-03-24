using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.Services.Implementation;
using Pathly.Services.Mappings;
using Pathly.Tests.Common;
using Pathly.ViewModels.Tags;
namespace Pathly.Tests;

[TestFixture]
public class TagServiceTests: ServiceTestsBase
{
    private TagService _tagService;

    [SetUp]
    public void SetupTagService()
    {
        BaseSetup();
        _tagService = new TagService(_mapper,_context);
    }

    [TearDown]
    public void TearDown() => BaseTearDown();

    [Test]
    public async Task CreateTagAsync_ShouldAddTag_WhenValid()
    {
        //Act
        await _tagService.CreateTagAsync("Work", "user1");
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == "Work");

        //Assert
        Assert.That(tag, Is.Not.Null);
        Assert.That(tag.Name, Is.EqualTo("Work"));
    }

    [Test]
    public async Task CreateTagAsync_ShouldThrow_WhenDuplicateName()
    {
        //Act
        await _tagService.CreateTagAsync("Work", "user1");
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _tagService.CreateTagAsync("work", "user1"));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("A tag with the same name already exists!"));
    }

    [Test]
    public async Task DeleteTagAsync_ShouldReturnTrue_WhenSuccessfull()
    {
        //Arrange
        var tag = new Tag { Name = "Personal", UserId = "user1" };
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        var tagCountBeforeDeleting = _context.Tags.Count();
        //Act
        var result = await _tagService.DeleteTagAsync(tag.Id, tag.UserId);
        //Assert
        Assert.That(result, Is.True);
        var tagCountAfterDeleting = _context.Tags.Count();
        Assert.That(tagCountAfterDeleting, Is.EqualTo(tagCountBeforeDeleting - 1));
    }

    [Test]
    public async Task DeleteTagAsync_ShouldReturnFalse_WhenUnsuccessfull()
    {
        //Act+Arrange
        var result = await _tagService.DeleteTagAsync(9999, "user1");
        //Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void DeleteTagAsync_ShouldThrowUnauthorized_WhenWrongUser()
    {
        //Arrange+Act
        var tag = new Tag { Name = "NotYours", UserId = "owner" };
        _context.Tags.Add(tag);
        _context.SaveChanges();

        //Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _tagService.DeleteTagAsync(tag.Id, "hacker-id"));
    }

    [Test]
    public async Task GetUserTagsAsync_ShouldReturnOnlyUserTags()
    {
        //Arrange
        _context.Tags.AddRange(
            new Tag { Name = "Tag1", UserId = "user1" },
            new Tag { Name = "Tag2", UserId = "user1" },
            new Tag { Name = "Tag3", UserId = "user2" }
        );
        await _context.SaveChangesAsync();
        //Act
        var tags = await _tagService.GetUserTagsAsync("user1");
        //Assert
        Assert.That(tags.Count(), Is.EqualTo(2));
        Assert.That(tags.Any(t => t.Name == "Tag1"), Is.True);
        Assert.That(tags.Any(t => t.Name == "Tag2"), Is.True);
        Assert.That(tags.Any(t => t.Name == "Tag3"), Is.False);
    }
}
