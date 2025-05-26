using WarehouseMaster.Common.DTO.Entrance;
using WarehouseMaster.Common.OperationResult;

namespace Warehouse.Core.Services.Interfaces
{
    public interface IEntranceService
    {
        Task<OperationResult<int>> CreateEntranceAsync(EntranceRequest request);
        Task<OperationResult<bool>> DeleteEntranceAsync(int id);
        Task<OperationResult<EntranceResponse>> GetEntranceByIdAsync(int id);
        Task<OperationResult<IEnumerable<EntranceResponse>>> GetAllEntranceAsync(int id);
        Task<OperationResult<bool>> IsExistEntranceAsync(int id);
    }
}
