namespace CC_SchoolProject_RestApi.PageModels
{
    public class TeacherAddressVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
       // public int AddressId { get; set; }
        public string? Username { get; set; }
        public DateTime StartDate { get; set; }
        public string? Status { get; set; }

        public string? AddressLine { get; set; }
        public string? Suburb { get; set; }
        public string? PostalCode { get; set; }
    }
}
