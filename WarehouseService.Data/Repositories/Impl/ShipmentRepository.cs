using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace WarehouseService.Data.Repositories.Impl
{
    public class ShipmentRepository(AppDbContext appDbContext)
        : BaseRepository<Shipment>(appDbContext), IShipmentRepository
    {
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
