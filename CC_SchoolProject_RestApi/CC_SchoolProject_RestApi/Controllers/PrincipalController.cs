using CC_SchoolProject_RestApi.AuthModels;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using CC_SchoolProject_RestApi.Repository;
using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace CC_SchoolProject_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        private static readonly ILog logger = LogManager.GetLogger("PrincipalController");
        private readonly CodeCrusaders_School_Management_DBContext _schoolContext;


        private UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationContext _authContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PrincipalController(CodeCrusaders_School_Management_DBContext context,
            UserManager<ApplicationUser> userManager,
            AuthenticationContext authContext,
            RoleManager<IdentityRole> roleManager)
        {
            _schoolContext = context;
            _userManager = userManager;
            _authContext = authContext;
            _roleManager = roleManager;
        }

        // GET: api/Principal/Learners 
        [Route("Learners")]
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<ActionResult<List<Learner>>> GetAllLearners()
        {
            logger.Info("PrincipalController - GET: api/Principal/Learners");
            try
            {
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allLearners = _principalRepository.GetLearnerList();
                logger.Info("All Learner retrieved successfully.");
                return Ok(allLearners);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching all learners. Exception: {ex}");
                return StatusCode(500, new { message = "An error occurred while fetching all learners." });
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Teacher/Status/{status}")]
        public async Task<ActionResult<List<Teacher>>> GetTeachersByStatus(string status)
        {
            logger.Info($"PrincipalController - GET: api/Principal/Teacher/Status/{status}");
            try
            {
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allPrincipal = _principalRepository.GetAllTeacherByStatus(status);
                logger.Info("All Teachers  retrieved successfully.");
                return Ok(allPrincipal);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching teachers by {status}. \nException: {ex}");
                return StatusCode(500, new { message = $"An error occurred while fetching teachers by status {status}." });
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Learner/Detailed")]
        public async Task<ActionResult<List<LearnerInfoReport>>> GetDetailedListOfLearner()
        {
            logger.Info($"PrincipalController - GET: api/Principal/Learner/Detailed");
            try
            {
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allLearnersInfo = _principalRepository.GetLearnerInformation();
                logger.Info("Detailed list of learner retrieved successfully.");
                return Ok(allLearnersInfo);
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred while fetching detailed list of learners. \nException: {ex}");
                return StatusCode(500, new { message = $"An error occurred while fetching detailed list of learners." });
            }
        }

        //GetTeacherSubjectInfo
        [EnableCors("AllowOrigin")]
        [HttpGet("TeacherSubject")]
        public async Task<ActionResult<List<TeacherSubjectReport>>> GetDetailedListTeacherSubject()
        {
            logger.Info($"PrincipalController - GET: api/Principal/TeacherSubject");
            try
            {
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allTeacherSubject = _principalRepository.GetTeacherSubjectInfo();
                logger.Info("Detailed list of teachers and their subjects retrieved successfully.");
                return Ok(allTeacherSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while fetching detailed list of teachers and their subjects." });
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Learner/Subject")]
        public async Task<ActionResult<List<LearnerSubjectReport>>> GetListLearnerSubject()
        {

            try
            {
                logger.Info($"PrincipalController - GET: api/Principal/Learner/Subject");
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allLearnerSubject = _principalRepository.GetLearnerSubjectInfo();
                logger.Info("List of learner and their subjects data retrieved successfully.");
                return Ok(allLearnerSubject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while fetching list of learners and their subjects." });
            }
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("Learner/Assessment")]
        public async Task<ActionResult<List<LearnerAssessmentsReport>>> GetListLearnerAssessment()
        {

            try
            {
                logger.Info($"PrincipalController - GET: api/Principal/Learner/Assessment");
                PrincipalRepo _principalRepository = new PrincipalRepo(_schoolContext);
                var allLearnerAssessment = _principalRepository.GetLearnerAssessmentInfo();
                logger.Info("List of learner and their assessment and mark obtained data retrieved successfully.");
                return Ok(allLearnerAssessment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while fetching list of learners and their assessment." });
            }
        }
    }
}
