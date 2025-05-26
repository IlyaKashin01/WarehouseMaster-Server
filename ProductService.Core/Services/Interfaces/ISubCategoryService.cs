using WarehouseMaster.Common.DTO.SubCategory;
using WarehouseMaster.Common.OperationResult;

namespace ProductService.Core.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<OperationResult<int>> CreateSubCategoryAsync(SubCategoryRequest request);
        Task<OperationResult<bool>> DeleteSubCategoryAsync(int id);
        Task<OperationResult<SubCategoryResponse>> GetSubCategoryByIdAsync(int id);
        Task<OperationResult<bool>> IsExistSubCategoryAsync(int id);
    }
}
