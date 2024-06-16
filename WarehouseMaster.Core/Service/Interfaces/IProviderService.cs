using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Entrance;
using WarehouseMaster.Core.DTO.Provider;

namespace WarehouseMaster.Core.Service.Interfaces
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
