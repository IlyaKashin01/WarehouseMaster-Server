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
        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime EntranceDate { get; set; }
        public Staffer Staffer { get; set; } = new Staffer();
        public int StafferId { get; set; }
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
