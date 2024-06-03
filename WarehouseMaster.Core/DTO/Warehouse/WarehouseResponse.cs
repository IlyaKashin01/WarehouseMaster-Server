using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Warehouse
{
    public class WarehouseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Square { get; set; }
        public int CountEmployees { get; set; }
        public int CountTechnic { get; set; }
        public int Capacity { get; set; }
        public int Occupancy { get; set; }
    }
}
