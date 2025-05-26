using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Data.Repositories.Interfaces
{
    public interface ISubCategoryRepository: IBaseRepository<SubCategory>
    {
        Task<SubCategory?> GetByNameAsync(string name);
    }
}
