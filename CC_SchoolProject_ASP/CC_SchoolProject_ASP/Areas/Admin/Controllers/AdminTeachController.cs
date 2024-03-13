using System.Net.Http.Json;
using CC_SchoolProject_ASP.Areas.Admin.Models;
using CC_SchoolProject_ASP.CCModels;
using CC_SchoolProject_ASP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CC_SchoolProject_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminTeachController : Controller
    {
        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;

        public AdminTeachController(IOptions<ClientSettings> ctSettings, HttpClient injectedClient)
        {
            _clientSettings = ctSettings.Value;
            _httpClient = injectedClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details()
        {
            List<Teacher> allTeachers = new List<Teacher>();
            string baseUrl = _clientSettings.ClientBaseUrl;
            string apiUrlTeacher = baseUrl + "/api/AdminTeachers/ReadAll";

            // https://localhost:7107/api/AdminTeachers/ReadAll

            HttpResponseMessage resp = await _httpClient.GetAsync(apiUrlTeacher);

            if (resp.IsSuccessStatusCode)
            {
                var results = resp.Content.ReadAsStringAsync().Result;
                allTeachers = JsonConvert.DeserializeObject<List<Teacher>>(results);
            }
            return View(allTeachers);
        }

        

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {

            string baseUrl = _clientSettings.ClientBaseUrl;
            string apiUrlTeacher = baseUrl + "/api/AdminTeachers";
            var postResponse = _httpClient.PostAsJsonAsync<Teacher>(apiUrlTeacher, teacher);
            postResponse.Wait();
            try
            {
                var result = postResponse.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
