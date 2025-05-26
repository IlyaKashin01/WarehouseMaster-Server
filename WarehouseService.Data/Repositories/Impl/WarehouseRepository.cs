using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;
using WarehouseService.Data.Repositories.Interfaces;

namespace WarehouseService.Data.Repositories.Impl
{
    public class WarehouseRepository(AppDbContext appDbContext)
        : BaseRepository<Warehouse>(appDbContext), IWarehouseRepository
    {
        public async Task<Warehouse?> GetWarehouseByNameAsync(string name)
        {
            return await _context.Warehouses.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }
    }
}
