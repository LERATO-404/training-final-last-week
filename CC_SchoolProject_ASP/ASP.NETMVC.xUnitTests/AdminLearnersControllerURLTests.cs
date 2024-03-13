using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC_SchoolProject_ASP;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ASP.NETMVC.xUnitTests
{
    public class AdminLearnersControllerURLTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;
        public AdminLearnersControllerURLTests(WebApplicationFactory<Program> factory)
        {
            _applicationFactory = factory;
        }

        [Theory]
        [InlineData("/Admin/AdminLearners/Details")]
        [InlineData("/Admin/AdminLearners/Create")]

        public async void _01_Test_All_AdminLearners_URL_ReturnsOkResponse(string URL)
        {
            var client = _applicationFactory.CreateClient();

            var response = await client.GetAsync(URL);
            int statusCode = (int)response.StatusCode;

            Assert.NotNull(response);
            Assert.Equal(200, statusCode);
        }
    }
}
