using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.DTO.Entrance
{
    public class EntranceRequest
    {
        public int WarehouseId { get; set; }
        public List<ProductRequest> Products { get; set; } =  new List<ProductRequest>();
        public DateTime EntranceDate { get; set; }
        public int StafferId { get; set; }
    }
}
