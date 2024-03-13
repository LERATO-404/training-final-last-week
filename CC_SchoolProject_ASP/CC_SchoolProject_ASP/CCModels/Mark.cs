using System;
using System.Collections.Generic;

namespace CC_SchoolProject_ASP.CCModels
{
    public partial class Mark
    {
        public int MarkId { get; set; }
        public int MarkObtained { get; set; }
        public string? Comment { get; set; }
        public int LearnerId { get; set; }
        public int AssessmentId { get; set; }

        public virtual Assessment Assessment { get; set; } = null!;
        public virtual Learner Learner { get; set; } = null!;
    }
}
