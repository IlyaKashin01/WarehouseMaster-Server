using WarehouseMaster.Common.DTO.Shipment;
using WarehouseMaster.Common.OperationResult;

namespace Warehouse.Core.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<OperationResult<int>> CreateShipmentAsync(ShipmentRequest request);
        Task<OperationResult<bool>> DeleteShipmentAsync(int id);
        Task<OperationResult<ShipmentResponse>> GetShipmentByIdAsync(int id);
        Task<OperationResult<IEnumerable<ShipmentResponse>>> GetAllShipmentAsync(int warehouseId);
        Task<OperationResult<bool>> IsExistShipmentAsync(int id);
    }
}
