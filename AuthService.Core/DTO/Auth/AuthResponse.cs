namespace AuthService.Core.DTO.Auth
{
#nullable disable
    public class AuthResponse
    {
        public PersonResponse Person { get; set; }
        public string Token { get; set; }
    }
}
