using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Category;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateCategoryAsync(CategoryRequest request);
        Task<bool> DeleteCategoryAsync(int id);
        Task<CategoryResponse> GetCategoryByIdAsync(int id);
        Task<bool> IsExistCategoryAsync(int id);
    }
}
