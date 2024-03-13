using System.ComponentModel.DataAnnotations;

namespace CC_SchoolProject_ASP.Models
{
    public class RegistrationVM
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? UserName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Email { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Password { get; set; }

        [StringLength(60, MinimumLength = 6)]
        [Required]
        public string? FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? LastName { get; set; }

        public string? Role { get; set; }
    }
}
