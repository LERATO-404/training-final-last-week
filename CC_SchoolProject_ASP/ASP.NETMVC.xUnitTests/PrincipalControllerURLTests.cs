using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC_SchoolProject_ASP;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ASP.NETMVC.xUnitTests
{
    public class PrincipalControllerURLTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;
        private readonly HttpClient _httpClient;

        public PrincipalControllerURLTests(WebApplicationFactory<Program> factory)
        {
            _applicationFactory = factory;
            _httpClient = _applicationFactory.CreateClient();
        }

        // All learners

        [Theory]
        [InlineData("Sophia Johnson")]
        [InlineData("Parent")]
        public async void _1_Test_Principal_GetLearnerInfo_Data_ReturnContent(string item)
        {

            // act
            var response = await _httpClient.GetAsync("Principal/Principal/GetLearnerInfo");
            var pageContent = await response.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();

            // assert

            Assert.Contains(item, contentString);
        }

        [Theory]
        [InlineData("Principal/Principal/GetLearnerInfo")]
        [InlineData("Principal/Principal/GetTeacherSubjectInfo")]
        [InlineData("Principal/Principal/GetLearnerAssessmentInfo")]
        public async void _2_Test_Principal_GetLearnerInfo_URL_ReturnsOkResponse(string URL)
        {
            // arrange
            var client = _applicationFactory.CreateClient();

            // act
            var response = await client.GetAsync(URL);
            int statusCode = (int)response.StatusCode;

            // assert
            Assert.NotNull(response);
            Assert.Equal(200, statusCode);
        }


        // View Teacher and Subject
        [Theory]
        [InlineData("Jason Miller")]
        [InlineData("Not Active")]
        [InlineData("Music Appreciation")]
        public async void _3_Test_Principal_GetTeacherSubjectInfo_Data_ReturnContent(string item)
        {

            // act
            var response = await _httpClient.GetAsync("Principal/Principal/GetTeacherSubjectInfo");
            var pageContent = await response.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();

            Assert.Contains(item, contentString);
        }

        // Learner and Assessment
        [Theory]
        [InlineData("Maths Assignment")]
        [InlineData("Physical Education")]
        [InlineData("Average performance. Consider improvement.")]
        [InlineData("62")]
        public async void _4_Test_Principal_GetLearnerAssessmentInfo_Data_ReturnContent(string item)
        {

            // act
            var response = await _httpClient.GetAsync("Principal/Principal/GetLearnerAssessmentInfo");
            var pageContent = await response.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();

            Assert.Contains(item, contentString);
        }
    }
}
