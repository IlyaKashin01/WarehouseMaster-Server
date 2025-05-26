using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace WarehouseService.Data.Repositories.Interfaces
{
    public interface IShipmentRepository: IBaseRepository<Shipment>
    {
        Task<IEnumerable<Shipment>> GetAllShipmentAsync(int warehouseId);
    }
}
