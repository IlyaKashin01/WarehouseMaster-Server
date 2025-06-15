using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Entrance;
using WarehouseMaster.Core.DTO.Provider;
using WarehouseMaster.Core.DTO.Staffer;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.DTO.Product
{
    public class ProductShortResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public Double Cost { get; set; }
        public int Count { get; set; }
        public string QRCode { get; set; } = string.Empty;
        public ProviderResponse Provider { get; set; } =  new ProviderResponse();
    }
}
