namespace AuthService.Core.DTO.Auth
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Login { get; set; } = "";
        public string Email { get; set; } = "";
        public string Avatar { get; set; } = "";
    }
}
