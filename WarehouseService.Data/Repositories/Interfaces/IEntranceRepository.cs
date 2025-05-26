using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace WarehouseService.Data.Repositories.Interfaces
{
    public interface IEntranceRepository: IBaseRepository<Entrance>
    {
        Task<IEnumerable<Entrance>> GetAll(int warehouseId);
    }
}
