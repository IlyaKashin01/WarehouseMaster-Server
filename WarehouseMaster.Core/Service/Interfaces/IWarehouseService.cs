using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Warehouse;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface IWarehouseService
    {
        Task<OperationResult<int>> CreateWarehouseAsync (WarehouseRequest request);
        Task<OperationResult<IEnumerable<WarehouseResponse>>> GetAllWarehousesAsync();
        Task<OperationResult<bool>> DeleteWarehouseAsync(int id);
    }
}
