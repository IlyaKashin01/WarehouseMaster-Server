using WarehouseMaster.Common.DTO.Provider;

namespace WarehouseMaster.Common.DTO.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public int StafferId { get; set; }
        public string QRCode { get; set; } = string.Empty;
        public ProviderResponse ProviderResponse { get; set; } = new ProviderResponse();
    }
}
