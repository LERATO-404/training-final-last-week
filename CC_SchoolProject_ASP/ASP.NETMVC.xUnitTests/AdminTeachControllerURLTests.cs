using Microsoft.AspNetCore.Mvc.Testing;
using CC_SchoolProject_ASP;

namespace ASP.NETMVC.xUnitTests
{

    public class AdminTeachControllerURLTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;
        public AdminTeachControllerURLTests(WebApplicationFactory<Program> factory)
        {
            _applicationFactory = factory;
        }

        [Theory]
        [InlineData("/Admin/AdminTeach/Index")]
        [InlineData("/Admin/AdminTeach/Details")]

        public async void _01_Test_All_AdminTeach_URL_ReturnsOkResponse(string URL)
        {
            var client = _applicationFactory.CreateClient();

            var response = await client.GetAsync(URL);
            int statusCode = (int)response.StatusCode;

            Assert.NotNull(response);
            Assert.Equal(200, statusCode);
        }
    }
}