using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.Category;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<OperationResult<int>> CreateCategoryAsync(CategoryRequest request);
        Task<OperationResult<bool>> DeleteCategoryAsync(int id);
        Task<OperationResult<CategoryResponse>> GetCategoryByIdAsync(int id);
        Task<OperationResult<bool>> IsExistCategoryAsync(int id);
    }
}
