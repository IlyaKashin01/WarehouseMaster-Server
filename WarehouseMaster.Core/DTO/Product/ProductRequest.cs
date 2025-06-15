using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Core.DTO.Product
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public Double Cost { get; set; }
        public int Count { get; set; }
        public int StafferId { get; set; }
        public int WarehouseId { get; set; }
        public int ProviderId  { get; set; }
    }
}
