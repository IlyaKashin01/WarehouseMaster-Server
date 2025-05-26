namespace WarehouseMaster.Common.DTO.SubCategory
{
    public class SubCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int StafferId { get; set; }
    }
}
