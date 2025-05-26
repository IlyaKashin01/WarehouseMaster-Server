namespace WarehouseMaster.Common.DTO.Provider
{
    public class ProviderResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
