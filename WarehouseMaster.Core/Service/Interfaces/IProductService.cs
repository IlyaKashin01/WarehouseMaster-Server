using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Product;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<int>> CreateProductAsync(ProductRequest request);
        Task<OperationResult<bool>> DeleteProductAsync(int id);
        Task<OperationResult<ProductResponse>> GetProductByIdAsync(int id);
        Task<OperationResult<bool>> IsExistProductAsync(int id);
        Task<OperationResult<IEnumerable<ProductResponse>>> GetAllProductsByWarehouseAsync(int warehouseId);
        string GenerateQrCode(Product product);

    }
}
