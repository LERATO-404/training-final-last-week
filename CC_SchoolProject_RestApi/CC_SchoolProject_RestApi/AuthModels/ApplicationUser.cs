using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_SchoolProject_RestApi.AuthModels
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }
    }

}
