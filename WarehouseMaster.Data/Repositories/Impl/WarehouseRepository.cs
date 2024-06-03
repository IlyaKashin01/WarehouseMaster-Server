using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
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
