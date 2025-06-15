using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Entrance: BaseEntity
    {
        public Warehouse Warehouse { get; set; } = new Warehouse();
        public int WarehouseId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int Quantity { get; set; }
        public DateTime EntranceDate { get; set; }
        public Staffer Staffer { get; set; } = new Staffer();
        public int StafferId { get; set; }
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
