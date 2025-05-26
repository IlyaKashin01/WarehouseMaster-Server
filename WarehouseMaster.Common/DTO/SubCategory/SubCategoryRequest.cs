using System.ComponentModel.DataAnnotations;

namespace WarehouseMaster.Common.DTO.SubCategory
{
    public class SubCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string NameCategory { get; set; } = string.Empty;
        [Required]
        public int StafferId { get; set; }
    }
}
