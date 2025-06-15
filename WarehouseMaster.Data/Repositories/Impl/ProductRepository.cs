using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllByWarehouseIdAsync(int warehouseId)
        {
            return await _context.Products.Where(p => p.WarehouseId == warehouseId)
                .Include(p => p.Staffer)
                .Include(p => p.Provider)
                .Include(p => p.Entrance)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Set<Product>().FindAsync(product.Id);

            if (existingProduct == null)
            {
                return false; 
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);

            await _context.SaveChangesAsync();

            return true; 
        }
        
        public new async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Set<Product>()
                .Where(p => p.Id == id)
                .Include(p => p.Staffer)
                .Include(p => p.Provider)
                .Include(p => p.Entrance)
                .FirstOrDefaultAsync();
        }
    }
}
