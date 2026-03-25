using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pathly.Data;
using Pathly.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Tests.Common
{
    public abstract class ServiceTestsBase
    {
        protected ApplicationDbContext _context;
        protected IMapper _mapper;

        public void BaseSetup()
        {
            // Create new ServiceProvider for each test
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var configurationMock = new Mock<IConfiguration>();

            configurationMock.Setup(c => c["SeedSettings:AdminPassword"]).Returns("TestPass123!");
            configurationMock.Setup(c => c["SeedSettings:TestUserPassword"]).Returns("TestPass123!");

            _context = new ApplicationDbContext(options,configurationMock.Object);
            _context.Database.EnsureCreated();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public void BaseTearDown()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
