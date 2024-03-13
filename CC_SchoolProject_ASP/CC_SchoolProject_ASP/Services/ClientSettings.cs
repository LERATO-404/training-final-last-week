namespace CC_SchoolProject_ASP.Services
{
    public class ClientSettings
    {
        public string? JWT_Token { get; set; }
        public string? CurrentUser { get; set; }
        public string? TokenExpiryInMinutes { get; set; }
        public string? ClientBaseUrl { get; set; }
    }
}
