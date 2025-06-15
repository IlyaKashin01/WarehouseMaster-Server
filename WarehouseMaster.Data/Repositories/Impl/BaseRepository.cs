using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class BaseRepository<TEntity>(AppDbContext appDbContext) : IBaseRepository<TEntity>
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
            if (await _context.Set<TEntity>().FindAsync(id) != null) return true;
            return false;
        }
    }
}
