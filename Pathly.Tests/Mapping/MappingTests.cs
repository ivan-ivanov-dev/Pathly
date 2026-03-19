using AutoMapper;
using Pathly.Services.Mappings;

namespace Pathly.Tests;

[TestFixture]
public class MappingTests
{
    [Test]
    public void AutoMapper_Configuration_Is_Valid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg =>
        {
            //add profiles here
            cfg.AddProfile<MappingProfile>();
        });

        // Act & Assert
        config.AssertConfigurationIsValid();
        //this method will throw an exception if any mapping configuration is invalid
    }
}
