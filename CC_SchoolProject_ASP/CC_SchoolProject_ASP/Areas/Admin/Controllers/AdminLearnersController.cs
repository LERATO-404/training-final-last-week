using CC_SchoolProject_ASP.Areas.Admin.Models;
using CC_SchoolProject_ASP.CCModels;
using CC_SchoolProject_ASP.Services;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CC_SchoolProject_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLearnersController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger("AdminLearnersController");

        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;

        public AdminLearnersController(IOptions<ClientSettings> ctSettings, HttpClient injectedClient)
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
            logger.Info("Details - Admin Get all Learners");

            List<Learner> allLearners = new List<Learner>();
            string baseUrl = _clientSettings.ClientBaseUrl;
            string apiUrlLearner = baseUrl + "/api/AdminLearners/GetAllLearners";

            // https://localhost:7107/api/AdminLearners/GetAllLearners

            HttpResponseMessage resp = await _httpClient.GetAsync(apiUrlLearner);

            if (resp.IsSuccessStatusCode)
            {
                var results = resp.Content.ReadAsStringAsync().Result;
                allLearners = JsonConvert.DeserializeObject<List<Learner>>(results);
            }
            return View(allLearners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LearnerGuardianAddressVM learner)
        {
            logger.Info("Create -  Admin create a new Learner");

            try
            {
                string baseUrl = _clientSettings?.ClientBaseUrl;
                string apiUrlLearner = baseUrl + "/api/AdminLearners/CreateNewLearner";

                // https://localhost:7107/api/AdminLearners/CreateNewLearner

                var postResponse = _httpClient.PostAsJsonAsync<LearnerGuardianAddressVM>(apiUrlLearner, learner);
                postResponse.Wait();

                var result = postResponse.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Details));
                }

                return View();
            }
            catch (Exception ex)
            {
                logger.Info("Create -  Create a new Learner failed : Error");

                return View();
            }
        }
    }
}
