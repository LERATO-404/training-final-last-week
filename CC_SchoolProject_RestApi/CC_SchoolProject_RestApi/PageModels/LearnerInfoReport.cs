namespace CC_SchoolProject_RestApi.PageModels
{
    public class LearnerInfoReport
    {
        //Learner
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // guardian
        public string GuardianFirstName { get; set; }
        public string GuardianLastName { get; set; }
        public string Relationship { get; set; }
        public string Contact { get; set; }

        // Address
        public string? AddressLine { get; set; }
        public string? Suburb { get; set; }
        public string? PostalCode { get; set; }

    }
}
