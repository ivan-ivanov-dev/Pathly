using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Moq;
using Pathly.DataModels;

namespace Pathly.Tests.Common
{
    public abstract class ControllerTestsBase
    {
        protected Mock<UserManager<ApplicationUser>> _mockUserManager;
        protected string _userId = "test-user-id";

        protected ControllerTestsBase()
        {
            // A Standard template for mocking of the UserManager
            var store = new Mock<IUserStore<ApplicationUser>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
        }

        protected void SetupUser(Controller controller)
        {
            // Simulates a User
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, _userId),
            new Claim(ClaimTypes.Name, "testuser@pathly.com")
            }, "mock"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            // UserManager returns our test=user-id
            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(_userId);
        }
    }
}
