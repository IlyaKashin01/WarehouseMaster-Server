using WarehouseMaster.Common.DTO.Warehouse;
using WarehouseMaster.Common.OperationResult;

namespace Warehouse.Core.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<OperationResult<int>> CreateWarehouseAsync (WarehouseRequest request);
        Task<OperationResult<IEnumerable<WarehouseResponse>>> GetAllWarehousesAsync();
        Task<OperationResult<bool>> DeleteWarehouseAsync(int id);
    }
}
