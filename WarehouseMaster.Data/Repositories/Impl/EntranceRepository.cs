using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class EntranceRepository(AppDbContext appDbContext)
        : BaseRepository<Entrance>(appDbContext), IEntranceRepository
    {
        public async Task<IEnumerable<Entrance>> GetAll(int warehouseId)
        {
            return await _context.Entrances
                .Where(x => x.WarehouseId == warehouseId)
                .Include(x => x.Staffer)
                .Include(x => x.Products)
                .ToListAsync();
        }
    }
}
