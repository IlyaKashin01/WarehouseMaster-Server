namespace AuthService.Core.DTO.Auth
{
    public class ChangePassRequest
    {
        public string Login { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
