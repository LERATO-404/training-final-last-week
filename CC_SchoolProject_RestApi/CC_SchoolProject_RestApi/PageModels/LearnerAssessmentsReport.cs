namespace CC_SchoolProject_RestApi.PageModels
{
    public class LearnerAssessmentsReport
    {
        //Learner
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Subject
        public string? SubjectName { get; set; }

        // Assessment
        public string? AssessmentName { get; set; }

        // Mark
        public int MarkObtained { get; set; }
        public string? Comment { get; set; }

    }
}
