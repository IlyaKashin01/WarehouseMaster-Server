using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Common.OperationResult;
using WarehouseMaster.Core.DTO.SubCategory;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface ISubCategoryService
    {
        Task<OperationResult<int>> CreateSubCategoryAsync(SubCategoryRequest request);
        Task<OperationResult<bool>> DeleteSubCategoryAsync(int id);
        Task<OperationResult<SubCategoryResponse>> GetSubCategoryByIdAsync(int id);
        Task<OperationResult<bool>> IsExistSubCategoryAsync(int id);
    }
}
