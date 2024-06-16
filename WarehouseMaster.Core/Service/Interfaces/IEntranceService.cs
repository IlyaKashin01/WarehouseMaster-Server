using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Entrance;

namespace WarehouseMaster.Core.Service.Interfaces
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
