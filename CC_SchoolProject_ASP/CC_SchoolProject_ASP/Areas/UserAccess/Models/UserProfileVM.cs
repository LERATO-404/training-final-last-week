﻿using System.ComponentModel.DataAnnotations;

namespace CC_SchoolProject_ASP.Models
{
    public class UserProfileVM
    {
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(25)]
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
