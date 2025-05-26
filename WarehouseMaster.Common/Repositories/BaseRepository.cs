using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Common.Repositories
{
    public class BaseRepository<TEntity>(AppDbContext appDbContext): IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context = appDbContext;

        public async Task<int> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) return false;

            entity.DeleteDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id) != null;
        }
    }
}
