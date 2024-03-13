using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key, Column("Subject_Id")]
        public int SubjectId { get; set; }

        [Column("Subject_Name")]
        public string SubjectName { get; set; }

        [Column("Subject_Code")]
        public string SubjectCode { get; set; }

        [Column("Subject_Description")]
        public string SubjectDescription { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
