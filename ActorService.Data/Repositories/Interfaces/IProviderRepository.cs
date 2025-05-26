using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace ActorService.Data.Repositories.Interfaces
{
    public interface IProviderRepository: IBaseRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetAllAsync();
    }
}
