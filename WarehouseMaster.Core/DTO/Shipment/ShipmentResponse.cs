using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.DTO.Shipment
{
    public class ShipmentResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public ProductResponse Product { get; set; } = new ProductResponse();
        public DateTime ShipmentDate { get; set; }
        public StafferResponse Staffer { get; set; } = new StafferResponse();
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
