using System;
using System.Collections.Generic;

namespace CC_SchoolProject_ASP.CCModels
{
    public partial class Learner
    {
        public Learner()
        {
            Marks = new HashSet<Mark>();
        }

        public int LearnerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GuardianId { get; set; }

        public virtual Guardian Guardian { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
