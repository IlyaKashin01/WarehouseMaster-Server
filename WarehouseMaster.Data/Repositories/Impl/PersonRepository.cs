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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<bool> CheckExistPersonByEmailAsync(string email)
        {
            var person = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (person != null) {
                return true;
            }
            return false;
        }
    }
}
