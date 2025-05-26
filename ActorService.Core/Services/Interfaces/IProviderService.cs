using WarehouseMaster.Common.DTO.Provider;
using WarehouseMaster.Common.OperationResult;

namespace ActorService.Core.Services.Interfaces
{
    public interface IProviderService
    {
        Task<OperationResult<int>> CreateProviderAsync(ProviderRequest request);
        Task<OperationResult<bool>> DeleteProviderAsync(int id);
        Task<OperationResult<ProviderResponse>> GetProviderByIdAsync(int id);
        Task<OperationResult<IEnumerable<ProviderResponse>>> GetAllProviderAsync();
        Task<OperationResult<bool>> IsExistProviderAsync(int id);
    }
}
