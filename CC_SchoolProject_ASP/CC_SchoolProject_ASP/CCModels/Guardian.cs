using System;
using System.Collections.Generic;

namespace CC_SchoolProject_ASP.CCModels
{
    public partial class Guardian
    {
        public Guardian()
        {
            Learners = new HashSet<Learner>();
        }

        public int GuardianId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Relationship { get; set; }
        public string? Contact { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Learner> Learners { get; set; }
    }
}
