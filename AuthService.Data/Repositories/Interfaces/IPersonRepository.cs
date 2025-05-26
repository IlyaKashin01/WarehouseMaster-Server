using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Domain.Entities;

namespace AuthService.Data.Repositories.Interfaces
{
    public interface IPersonRepository: IBaseRepository<Person>

    {
    Task<bool> CheckExistPersonByEmailAsync(string email);
    Task<Person?> FindByLoginAsync(string login);
    }
}
