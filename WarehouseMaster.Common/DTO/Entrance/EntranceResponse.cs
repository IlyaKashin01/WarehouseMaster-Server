using WarehouseMaster.Common.DTO.Product;
using WarehouseMaster.Common.DTO.Staffer;

namespace WarehouseMaster.Common.DTO.Entrance
{
    public class EntranceResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public ProductResponse Product { get; set; } = new ProductResponse();
        public DateTime EntranceDate { get; set; }
        public StafferResponse Staffer { get; set; } = new StafferResponse();
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
