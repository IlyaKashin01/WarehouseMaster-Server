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
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string NameCategory { get; set; } = string.Empty;
        public string NameSubCategory { get; set; } = string.Empty;
        [Required]
        public Double Cost { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int StafferId { get; set; }
    }
}
