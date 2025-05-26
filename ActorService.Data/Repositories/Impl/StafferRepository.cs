using ActorService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Data.Repositories.Impl
{
    public class StafferRepository(AppDbContext appDbContext): BaseRepository<Staffer>(appDbContext), IStafferRepository
    {
        public async Task<IEnumerable<Staffer>> GetAllAsync()
        {
           return await _context.Staffers.ToListAsync();
        }
    }
}
