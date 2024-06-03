using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.Service.Interfaces
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
