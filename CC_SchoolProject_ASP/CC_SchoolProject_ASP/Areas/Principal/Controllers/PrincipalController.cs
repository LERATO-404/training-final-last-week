using CC_SchoolProject_ASP.Services;
using CC_SchoolProject_ASP.ViewModels;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CC_SchoolProject_ASP.Areas.Principal.Controllers
{
    [Area("Principal")]
    public class PrincipalController : Controller
    {

        private static readonly ILog logger = LogManager.GetLogger("PrincipalController");
        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;

        public PrincipalController(IOptions<ClientSettings> ctSettings, HttpClient injectedClient)
        {
            _clientSettings = ctSettings.Value;
            _httpClient = injectedClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        // get detailed list of all the learner
        public async Task<IActionResult> GetLearnerInfo()
        {
            logger.Info("Fetching all learnes information for the Principal GetLearnerInfo action");

            try
            {
                List<LearnerInfoReport> learnerInformation = new List<LearnerInfoReport>();
                string baseUrl = _clientSettings.ClientBaseUrl;
                string apiUrlLearnerInfo = baseUrl + "/api/Principal/Learner/Detailed";
                HttpResponseMessage resp = await _httpClient.GetAsync(apiUrlLearnerInfo);

                if (resp.IsSuccessStatusCode)
                {
                    var results = await resp.Content.ReadAsStringAsync();
                    learnerInformation = JsonConvert.DeserializeObject<List<LearnerInfoReport>>(results);
                    logger.Info($"Successfully retrieved {learnerInformation.Count} learners.");
                }
                else
                {
                    logger.Warn("Failed to fetch learners: HTTP status code indicates failure.");
                }
                return View(learnerInformation);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching learners: {ex.Message}");
                return View();
            }
        }

        // get all the teacher subject

        public async Task<IActionResult> GetTeacherSubjectInfo()
        {
            logger.Info("Fetching all teacher information for the Principal GetTeacherInfo action");

            try
            {
                List<TeacherSubjectReport> teacherInformation = new List<TeacherSubjectReport>();
                string baseUrl = _clientSettings.ClientBaseUrl;
                string apiUrlTeacherInfo = baseUrl + "/api/Principal/TeacherSubject";
                HttpResponseMessage resp = await _httpClient.GetAsync(apiUrlTeacherInfo);

                if (resp.IsSuccessStatusCode)
                {
                    var results = await resp.Content.ReadAsStringAsync();
                    teacherInformation = JsonConvert.DeserializeObject<List<TeacherSubjectReport>>(results);
                    logger.Info($"Successfully retrieved {teacherInformation.Count} teachers.");
                }
                else
                {
                    logger.Warn("Failed to fetch teachers with their subject: HTTP status code indicates failure.");
                }
                return View(teacherInformation);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching teachers: {ex.Message}");
                return View();
            }
        }


        // Get learner, subject, assessment, and mark obtained
        public async Task<IActionResult> GetLearnerAssessmentInfo()
        {
            logger.Info("Fetching all learners and assessment information for the Principal GetLearnerAssessmentInfo action");

            try
            {
                List<LearnerAssessmentsReport> learnerAssessInformation = new List<LearnerAssessmentsReport>();
                string baseUrl = _clientSettings.ClientBaseUrl;
                string apiUrllLearnerAsmInfo = baseUrl + "/api/Principal/Learner/Assessment";
                HttpResponseMessage resp = await _httpClient.GetAsync(apiUrllLearnerAsmInfo);

                if (resp.IsSuccessStatusCode)
                {
                    var results = await resp.Content.ReadAsStringAsync();
                    learnerAssessInformation = JsonConvert.DeserializeObject<List<LearnerAssessmentsReport>>(results);
                    logger.Info($"Successfully retrieved {learnerAssessInformation.Count} learners.");
                }
                else
                {
                    logger.Warn("Failed to fetch learners and their assessments : HTTP status code indicates failure.");
                }
                return View(learnerAssessInformation);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching learners and their assessments: {ex.Message}");
                return View();
            }
        }

    }
}
