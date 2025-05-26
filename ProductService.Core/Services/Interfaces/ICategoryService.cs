using WarehouseMaster.Common.DTO.Category;
using WarehouseMaster.Common.OperationResult;

namespace ProductService.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<OperationResult<int>> CreateCategoryAsync(CategoryRequest request);
        Task<OperationResult<bool>> DeleteCategoryAsync(int id);
        Task<OperationResult<CategoryResponse>> GetCategoryByIdAsync(int id);
        Task<OperationResult<bool>> IsExistCategoryAsync(int id);
    }
}
