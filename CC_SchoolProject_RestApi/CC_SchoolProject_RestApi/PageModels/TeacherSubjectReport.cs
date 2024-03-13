namespace CC_SchoolProject_RestApi.PageModels
{
    public class TeacherSubjectReport
    {
        // Teacher

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }

        //Subject

        public string? SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }
    }
}
