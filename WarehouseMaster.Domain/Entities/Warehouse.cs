using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class Warehouse: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Square { get; set; }
        public int CountEmployees { get; set; }
        public int CountTechnic {  get; set; }
        public int Capacity { get; set; }
        public int Occupancy { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime CreatedDate { get; set; }
    }
}
