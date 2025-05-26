using AuthService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace AuthService.Data.Repositories.Impl
{
    public class PersonRepository(AppDbContext appDbContext) : BaseRepository<Person>(appDbContext), IPersonRepository
    {
        public async Task<bool> CheckExistPersonByEmailAsync(string email)
        {
            var person = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return person != null;
        }
        
        public async Task<Person?> FindByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}