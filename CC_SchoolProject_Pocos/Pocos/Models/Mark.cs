using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("Marks")]
    public class Mark
    {
        [Key, Column("Mark_Id")]
        public int MarkId { get; set; }

        [Column("Mark_Obtained")]
        public int MarkObtained { get; set; }

        [Column("Comment")]
        public string Comment { get; set; }

        [ForeignKey("Learners"), Column("Learner_Id")]
        public int LearnerId { get; set; }
        public virtual Learner Learners { get; set; }

        [ForeignKey("Assessments"), Column("Assessment_Id")]
        public int AssessmentId { get; set; }

        public virtual Assessment Assessments { get; set; }
    }
}
