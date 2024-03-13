namespace CC_SchoolProject_RestApi.PageModels
{
    public class LearnerGuardianAddressVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? GuardianFirstName { get; set; }
        public string? GuardianLastName { get; set; }
        public string? Relationship { get; set; }
        public string? Contact { get; set; }

        public string? AddressLine { get; set; }
        public string? Suburb { get; set; }
        public string? PostalCode { get; set; }
    }
}
