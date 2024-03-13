using System.ComponentModel.DataAnnotations;

namespace CC_SchoolProject_RestApi.AuthModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
