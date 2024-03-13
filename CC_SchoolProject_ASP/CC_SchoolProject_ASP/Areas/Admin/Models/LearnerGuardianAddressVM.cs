namespace CC_SchoolProject_ASP.Areas.Admin.Models
{
    public class LearnerGuardianAddressVM
    {
        // Learner
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Guardian
        public string? GuardianFirstName { get; set; }
        public string? GuardianLastName { get; set; }
        public string? Relationship { get; set; }
        public string? Contact { get; set; }

        // Address
        public string? AddressLine { get; set; }
        public string? Suburb { get; set; }
        public string? PostalCode { get; set; }
    }
}
