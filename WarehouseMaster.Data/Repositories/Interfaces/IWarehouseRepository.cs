using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Interfaces
{
    public interface IWarehouseRepository: IBaseRepository<Warehouse>
    {
        Task<Warehouse?> GetWarehouseByNameAsync(string name);
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
    }
}
