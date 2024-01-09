using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Staffer;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface IStafferService
    {
        Task<int> CreateStafferAsync(StafferRequest request);
        Task<bool> DeleteStafferAsync(int id);
        Task<StafferResponse> GetStafferByIdAsync(int id);
        Task<bool> IsExistStafferAsync(int id);
    }
}
