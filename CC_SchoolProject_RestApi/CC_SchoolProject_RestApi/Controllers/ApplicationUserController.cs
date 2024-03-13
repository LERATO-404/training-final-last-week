using CC_SchoolProject_RestApi.AuthModels;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using CC_SchoolProject_RestApi.Repositories;
using CC_SchoolProject_RestApi.Repository;
using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CC_SchoolProject_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private static readonly ILog logger = LogManager.GetLogger("ApplicationUserController");

        private readonly CodeCrusaders_School_Management_DBContext _schoolContext;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings, CodeCrusaders_School_Management_DBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _schoolContext = context;
        }


        [HttpPost]
        [Route("Register")]
        [EnableCors("AllowOrigin")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            logger.Info("Post : /api/ApplicationUser/Register");

            try
            {
                // Add the teacher
                var teacher = new TeacherRegister()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.Email,
                    Username = model.UserName,
                };             

                var appUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };


                // assigned teacher role if the role is not specified
                if (model.Role == null || model.Role == "")
                {
                    model.Role = "Teacher";
                    logger.Info("Role not specified. Defaulting to 'Teacher' role.");
                }
                try
                {

                    ////var result = await _userManager.CreateAsync(appUser, model.Password);
                    ////if (result.Succeeded)
                    ////{
                    ////    logger.Info($"User {appUser.FirstName} {appUser.LastName} created successfully.");

                    ////    var userResult = await _userManager.AddToRoleAsync(appUser, model.Role);

                    ////    _schoolContext.Teachers.Add(newTeacher);
                    ////    await _schoolContext.SaveChangesAsync();
                    ////}
                    ////return Ok(new { username = model.UserName, message = $"User {appUser.FirstName} {appUser.LastName} Created Successfully." });

                    //if (model.Role == "Teacher")
                    //{
                    //    logger.Info("Role specified as 'Teacher'. Adding teacher information.");
                    //}

                    //var result = await _userManager.CreateAsync(appUser, model.Password);
                    //if (result.Succeeded)
                    //{
                    //    logger.Info($"User {appUser.FirstName} {appUser.LastName} created successfully.");

                    //    var userResult = await _userManager.AddToRoleAsync(appUser, model.Role);
                    //}
                    //return Ok(new { username = model.UserName, message = $"User {appUser.FirstName} {appUser.LastName} Created Successfully." });

                    if (model.Role == "Teacher")
                    {
                        logger.Info("Role specified as 'Teacher'. Adding teacher information.");
                       PrincipalRepo _principalRepo = new PrincipalRepo(_schoolContext);
                       _principalRepo.CreateNewTeacher(teacher);
                    }

                    var result = await _userManager.CreateAsync(appUser, model.Password);
                    if (result.Succeeded)
                    {
                        logger.Info($"User {appUser.FirstName} {appUser.LastName} created successfully.");

                        var userResult = await _userManager.AddToRoleAsync(appUser, model.Role);
                    }


                    return Ok(new { username = model.UserName, message = $"User {appUser.FirstName} {appUser.LastName} Created Successfully." });
                }
                catch (Exception ex)
                {
                    logger.Error($"Failed to create user. Exception: {ex}");
                    return BadRequest(new { message = "Failed to create user. Try again later." + ex });
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during user creation. Exception: {ex}");
                return BadRequest(new { message = "Failed to create user. Try again later." });
            }





        }

        [HttpPost]
        [Route("Login")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Login(LoginModel model)
        {

            try
            {
                logger.Info("Post : /api/ApplicationUser/Login");

                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {

                    var claim = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserID", user.Id.ToString())
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.SigningKey));
                    string tmpKeyIssuer = _appSettings.JWT_Site_URL;
                    int expiryInMinutes = Convert.ToInt32(_appSettings.ExpiryInMinutes);


                    var usrToken = new JwtSecurityToken(
                        claims: claim,
                        expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(usrToken),
                        expiration = usrToken.ValidTo,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        roles = await _userManager.GetRolesAsync(user)
                    });

                }
                else
                {
                    logger.Warn("User login failed. Username or password not found.");
                    return BadRequest(new { message = "Username or password not found." });
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during user login. Exception: {ex}");
                return BadRequest(new { message = "Failed to authenticate. Try again later." });
            }


        }
    }
}
