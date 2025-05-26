namespace AuthService.Core.DTO.Auth
{
    public class TelegramAuthRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public long AuthDate { get; set; }
        public string Hash { get; set; } = string.Empty;
    }
}
