using Microsoft.EntityFrameworkCore;
using ProductService.Data.Repositories.Interfaces;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Data.Repositories.Impl
{
    public class SubCategoryRepository: BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(AppDbContext context): base(context) { }

        public async Task<SubCategory?> GetByNameAsync(string name)
        {
            return await _context.SubCategories.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
