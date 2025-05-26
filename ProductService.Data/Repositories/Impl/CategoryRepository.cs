using Microsoft.EntityFrameworkCore;
using ProductService.Data.Repositories.Interfaces;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Data.Repositories.Impl
{
    public class CategoryRepository(AppDbContext context): BaseRepository<Category>(context), ICategoryRepository
    {
        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
