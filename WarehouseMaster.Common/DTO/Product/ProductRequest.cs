using System.ComponentModel.DataAnnotations;

namespace WarehouseMaster.Common.DTO.Product
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
        [Required]
        public int WarehouseId { get; set; }
    }
}
