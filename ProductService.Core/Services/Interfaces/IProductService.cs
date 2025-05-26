using WarehouseMaster.Common.DTO.Product;
using WarehouseMaster.Common.OperationResult;

namespace ProductService.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<int>> CreateProductAsync(ProductRequest request);
        Task<OperationResult<bool>> DeleteProductAsync(int id);
        Task<OperationResult<ProductResponse>> GetProductByIdAsync(int id);
        Task<OperationResult<bool>> IsExistProductAsync(int id);
    }
}
