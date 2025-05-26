namespace WarehouseMaster.Common.DTO.Entrance
{
    public class EntranceRequest
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime EntranceDate { get; set; }
        public int StafferId { get; set; }
    }
}
