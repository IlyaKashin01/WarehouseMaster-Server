using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace WarehouseService.Data.Repositories.Interfaces
{
    public interface IWarehouseRepository: IBaseRepository<Warehouse>
    {
        Task<Warehouse?> GetWarehouseByNameAsync(string name);
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
    }
}
