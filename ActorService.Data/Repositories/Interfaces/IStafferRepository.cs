using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Data.Repositories.Interfaces
{
    public interface IStafferRepository: IBaseRepository<Staffer>
    {
        Task<IEnumerable<Staffer>> GetAllAsync();
    }
}
