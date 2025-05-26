namespace WarehouseMaster.Common.DTO.Shipment
{
    public class ShipmentRequest
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int StafferId { get; set; }
    }
}
