using System;
using System.Collections.Generic;

namespace CC_SchoolProject_RestApi.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int? AddressId { get; set; }
        public string? Username { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Status { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
