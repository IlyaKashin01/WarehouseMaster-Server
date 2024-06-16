using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class EntranceRepository : BaseRepository<Entrance>, IEntranceRepository
    {
        public EntranceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

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
