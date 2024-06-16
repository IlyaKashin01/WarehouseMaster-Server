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
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }
    }
}
