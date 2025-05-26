namespace AuthService.Core.DTO.Auth
{
    public class CodeRequest
    {
        public string Login { get; set; } = string.Empty;
        public int ResetCode { get; set; }
    }
}
