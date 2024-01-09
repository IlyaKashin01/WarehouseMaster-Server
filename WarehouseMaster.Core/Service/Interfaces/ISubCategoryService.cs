using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.SubCategory;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface ISubCategoryService
    {
        Task<int> CreateSubCategoryAsync(SubCategoryRequest request);
        Task<bool> DeleteSubCategoryAsync(int id);
        Task<SubCategoryResponse> GetSubCategoryByIdAsync(int id);
        Task<bool> IsExistSubCategoryAsync(int id);
    }
}
