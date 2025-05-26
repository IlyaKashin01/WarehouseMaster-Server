using System.ComponentModel.DataAnnotations;

namespace WarehouseMaster.Common.DTO.Category
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int StafferId { get; set; }
    }
}
