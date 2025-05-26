using WarehouseMaster.Common.DTO.Staffer;
using WarehouseMaster.Common.OperationResult;

namespace ActorService.Core.Services.Interfaces
{
    public interface IStafferService
    {
        Task<OperationResult<int>> CreateStafferAsync(StafferRequest request);
        Task<OperationResult<bool>> DeleteStafferAsync(int id);
        Task<OperationResult<StafferResponse>> GetStafferByIdAsync(int id);
        Task<OperationResult<IEnumerable<StafferResponse>>> GetAllStaffersAsync();
        Task<OperationResult<bool>> IsExistStafferAsync(int id);
    }
}
