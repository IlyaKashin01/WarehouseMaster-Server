using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Common.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
