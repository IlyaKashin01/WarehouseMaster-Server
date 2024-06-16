using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Interfaces
{
    public interface IEntranceRepository: IBaseRepository<Entrance>
    {
        Task<IEnumerable<Entrance>> GetAll(int warehouseId);
    }
}
