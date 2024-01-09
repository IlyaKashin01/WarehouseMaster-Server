using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Data.Repositories.Interfaces;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Impl
{
    public class StafferRepository: BaseRepository<Staffer>, IStafferRepository
    {
        public StafferRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
