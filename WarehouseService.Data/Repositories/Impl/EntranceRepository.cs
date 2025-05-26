using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace WarehouseService.Data.Repositories.Impl
{
    public class EntranceRepository(AppDbContext appDbContext)
        : BaseRepository<Entrance>(appDbContext), IEntranceRepository
    {
        public async Task<IEnumerable<Entrance>> GetAll(int warehouseId)
        {
            return await _context.Entrances
                .Where(x => x.WarehouseId == warehouseId)
                .Include(x => x.Staffer)
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
