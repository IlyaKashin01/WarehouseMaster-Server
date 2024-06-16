using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class ShipmentRepository : BaseRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentAsync(int warehouseId)
        {
            return await _context.Shipments
                .Where(x => x.WarehouseId == warehouseId)
                .Include(x => x.Staffer)
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
