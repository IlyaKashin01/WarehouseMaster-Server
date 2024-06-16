using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Core.DTO.Shipment;

namespace WarehouseMaster.Core.Service.Interfaces
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
