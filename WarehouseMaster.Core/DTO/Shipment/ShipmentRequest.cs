using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Shipment
{
    public class ShipmentRequest
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int StafferId { get; set; }
    }
}
