using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("TeacherSubjects")]
    public class TeacherSubject
    {
        [Key, Column("TeacherSubject_Id")]
        public int TeacherSubjectId { get; set; }

        [ForeignKey("Subjects"), Column("Subject_Id")]
        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }

        [ForeignKey("Teachers"), Column("Teacher_Id")]
        public int TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; }
    }
}
