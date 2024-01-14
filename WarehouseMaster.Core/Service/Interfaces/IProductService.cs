using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Product;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<int>> CreateProductAsync(ProductRequest request);
        Task<OperationResult<bool>> DeleteProductAsync(int id);
        Task<OperationResult<ProductResponse>> GetProductByIdAsync(int id);
        Task<OperationResult<bool>> IsExistProductAsync(int id);
    }
}
