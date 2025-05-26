using ActorService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Data.Repositories.Impl
{
    public class ProviderRepository(AppDbContext appDbContext)
        : BaseRepository<Provider>(appDbContext), IProviderRepository
    {
        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }
    }
}
