namespace CC_SchoolProject_RestApi.PageModels
{
    public class TeacherVM
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
       // public int AddressId { get; set; }
        public string? Username { get; set; }
        public DateTime StartDate { get; set; }
    }
}
