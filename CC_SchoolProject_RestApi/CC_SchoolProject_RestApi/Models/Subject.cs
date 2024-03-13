using System;
using System.Collections.Generic;

namespace CC_SchoolProject_RestApi.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Assessments = new HashSet<Assessment>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
