using System;
using System.Collections.Generic;

namespace CC_SchoolProject_ASP.CCModels
{
    public partial class Assessment
    {
        public Assessment()
        {
            Marks = new HashSet<Mark>();
        }

        public int AssessmentId { get; set; }
        public string? AssessmentName { get; set; }
        public int SubjectId { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
