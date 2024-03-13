using CC_SchoolProject_RestApi.AuthModels;
using CC_SchoolProject_RestApi.Controllers;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.Repository;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.NunitTests
{
    public class PrincipalControllerTests
    {

        private PrincipalController _controller;
        private Mock<CodeCrusaders_School_Management_DBContext> _mockContext;
        private Mock<PrincipalRepo> _mockPrincipalRepo;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<AuthenticationContext> _mockAuthContext;
        private Mock<RoleManager<IdentityRole>> _mockRoleManager;

        [SetUp]
        public void Initialiser()
        {
            _mockContext = new Mock<CodeCrusaders_School_Management_DBContext>();
            _mockPrincipalRepo = new Mock<PrincipalRepo>(_mockContext.Object);
            _mockUserManager = new Mock<UserManager<ApplicationUser>>();
            _mockAuthContext = new Mock<AuthenticationContext>();
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>();
        }
    }
}
