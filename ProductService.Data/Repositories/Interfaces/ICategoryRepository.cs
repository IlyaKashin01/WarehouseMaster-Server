using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Data.Repositories.Interfaces
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}
