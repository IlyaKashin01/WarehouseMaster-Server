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
    public class SubCategoryRepository: BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(AppDbContext context): base(context) { }

        public async Task<SubCategory?> GetByNameAsync(string name)
        {
            return await _context.SubCategories.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
