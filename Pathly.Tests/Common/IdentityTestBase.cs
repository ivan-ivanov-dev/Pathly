using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Pathly.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Tests.Common
{
    public abstract class IdentityTestBase
    {
        protected Mock<UserManager<ApplicationUser>> MockUserManager;
        protected Mock<SignInManager<ApplicationUser>> MockSignInManager;

        [SetUp]
        public virtual void Setup()
        {
            // Specific Setup for UserManager
            var store = new Mock<IUserStore<ApplicationUser>>();
            MockUserManager = new Mock<UserManager<ApplicationUser>>(
                store.Object, null, null, null, null, null, null, null, null);

            // Specific Setup for SignInManager
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            MockSignInManager = new Mock<SignInManager<ApplicationUser>>(
                MockUserManager.Object,
                contextAccessor.Object,
                claimsFactory.Object,
                null, null, null, null);
        }
    }
}
