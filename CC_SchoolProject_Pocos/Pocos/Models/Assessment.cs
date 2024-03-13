using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pocos.Models
{
    [Table("Assessments")]
    public class Assessment
    {
        [Key, Column("Assessment_Id")]
        public int AssessmentId { get; set; }

        [Column("Assessment_Name")]
        public string AssessmentName { get; set; }

        [ForeignKey("Subjects"), Column("SubjectId")]
        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }

        [Column("Due_Date")]
        public DateTime DueDate { get; set; }
    }
}
