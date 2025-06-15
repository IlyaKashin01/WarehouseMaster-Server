using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.DTO.Entrance
{
    public class EntranceShortResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime EntranceDate { get; set; }
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
