using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subcategory {  get; set; } = string.Empty;
        public Double Cost { get; set; }
        public int Count { get; set; }
        public Staffer Staffer { get; set; } = new Staffer();
        public int StafferId { get; set; }
        public Warehouse Warehouse { get; set; } = new Warehouse();
        public int WarehouseId { get; set; }
        public Entrance? Entrance { get; set; } = new Entrance();
        public int? EntranceId { get; set; }
        public string QRCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Provider Provider { get; set; } = new Provider();
        public int ProviderId { get; set; }
    }
}
