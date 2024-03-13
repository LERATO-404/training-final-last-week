using CC_SchoolProject_ASP.Models;
using CC_SchoolProject_ASP.Services;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CC_SchoolProject_ASP.Areas.UserAccess.Controllers
{
    [Area("UserAccess")]
    public class UserManagerController : Controller
    {

        private static readonly ILog logger = LogManager.GetLogger("UserManagerController");
        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;

        public UserManagerController(IOptions<ClientSettings> ctSettings, HttpClient injectedClient)
        {
            _clientSettings = ctSettings.Value;
            _httpClient = injectedClient;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationVM usrRegData)
        {

            logger.Info($"Post : /api/ApplicationUser/Register \n");
            try
            {
                UserRegisteredVM newlyRegUser = new UserRegisteredVM();
                string baseUrl = _clientSettings.ClientBaseUrl;
                string apiUrlRegister = baseUrl + "/api/ApplicationUser/Register";


                logger.Info($"Base URL : {baseUrl}");

                var postResponse = _httpClient.PostAsJsonAsync<RegistrationVM>(apiUrlRegister, usrRegData);
                postResponse.Wait();
                var result = postResponse.Result;

                ViewBag.POSTresultHeader = result.Headers;
                ViewBag.POSTresultStatusCode = result.StatusCode;
                ViewBag.POSTresultRequestMessage = result.RequestMessage;
                ViewBag.POSTresultIsSuccessStatusCode = result.IsSuccessStatusCode;

                if (result.IsSuccessStatusCode)
                {
                    logger.Info("Registration successful. Parsing response.");
                    var results = result.Content.ReadAsStringAsync().Result;
                    newlyRegUser = JsonConvert.DeserializeObject<UserRegisteredVM>(results);

                }

                TempData["LoginSuccessMessage"] = $"User {newlyRegUser.UserName} registered successfully!";
                TempData["POSTRegUserUserName"] = newlyRegUser.UserName;
                TempData.Keep();

                logger.Info($"Redirecting to Index action in Home controller (area: default).");
                return RedirectToAction("Login", "UserManager", new { area = "UserAccess" });
            }
            catch (Exception e)
            {
                logger.Error($"HttpPost - Registration - UserName: " + usrRegData.UserName + " Exception: {e}");

                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVM usrLogin)
        {
            logger.Info($"Post : /api/ApplicationUser/Login \n");
            logger.Info("HttpPost - Login - UserName: " + usrLogin.UserName);

            try
            {
                CurrentUserVM currentLoggedInUser = new CurrentUserVM();
                string baseUrl = _clientSettings.ClientBaseUrl;

                logger.Info("BaseUrl:"+ baseUrl);
                string apiUrlLogin = baseUrl + "/api/ApplicationUser/Login";

                //Set home url for user after successful login
                string userHomePageUrl = baseUrl + "/Home/Index";

                var postResponse = _httpClient.PostAsJsonAsync<LoginVM>(apiUrlLogin, usrLogin);
                postResponse.Wait();
                var result = postResponse.Result;

                logger.Info("HttpPost - Login: Login page result: " + result);

                ViewBag.POSTresultHeader = result.Headers;
                ViewBag.POSTresultStatusCode = result.StatusCode;
                ViewBag.POSTresultRequestMessage = result.RequestMessage;
                ViewBag.POSTresultIsSuccessStatusCode = result.IsSuccessStatusCode;

                if (result.IsSuccessStatusCode)
                {
                    logger.Info("Registration successful. Parsing response.");
                    var results = result.Content.ReadAsStringAsync().Result;
                    currentLoggedInUser = JsonConvert.DeserializeObject<CurrentUserVM>(results);
                }

                //storing data into tempdata  
                TempData["UserHomePageUrl"] = userHomePageUrl;
                TempData["UserToken"] = currentLoggedInUser.Token;
                TempData["UserTokenValidTo"] = currentLoggedInUser.Expiration;
                TempData["FirstName"] = currentLoggedInUser.FirstName;
                TempData["LastName"] = currentLoggedInUser.LastName;
                TempData["UserName"] = currentLoggedInUser.UserName;
                TempData["UserRole"] = currentLoggedInUser.Roles[0];
                TempData.Keep();


                if (result.IsSuccessStatusCode)
                {
                    if (currentLoggedInUser != null && currentLoggedInUser.Roles[0] == "Administrator")
                    {
                        TempData["UserHomePageUrl"] = "/Admin/Home/Index";
                        TempData.Keep();
                        logger.Info($"Redirecting to Index action in AdminTeach Controller.");
                        return RedirectToAction("Index", "AdminTeach", new { area = "Admin" });
                    }
                    else if (currentLoggedInUser != null && currentLoggedInUser.Roles[0] == "Teacher")
                    {
                        TempData["UserHomePageUrl"] = "/Teacher/Home/Index";
                        TempData.Keep();
                        logger.Info($"Redirecting to Index action in Teacher Controller.");
                        return RedirectToAction("Index", "Teacher", new { area = "Teachers" });
                    }
                    else if (currentLoggedInUser != null && currentLoggedInUser.Roles[0] == "Principal")
                    {
                        TempData["UserHomePageUrl"] = "/Principal/Home/Index";
                        TempData.Keep();
                        logger.Info($"Redirecting to Index action in Principal Controller.");
                        return RedirectToAction("Index", "Principal", new { area = "Principal" });
                    }
                    else
                    {
                       
                        TempData["UserHomePageUrl"] = "/Home/Index";
                        TempData.Keep();
                        logger.Info($"Redirecting to Home Index.");
                        return RedirectToAction("Index", "Home", new { area = "default" });
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                logger.Error("HttpPost - Login - UserName: " + usrLogin.UserName + " Exception: " + e);

                return View();
            }
        }

        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Login", "UserManager", new { area = "UserAccess" });
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
