﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.DTO.Entrance
{
    public class EntranceResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public List<ProductShortResponse> Products { get; set; } = new List<ProductShortResponse>();
        public DateTime EntranceDate { get; set; }
        public StafferResponse Staffer { get; set; } = new StafferResponse();
        public bool Status { get; set; }
        public DateTime AcceptDate { get; set; }
    }
}
