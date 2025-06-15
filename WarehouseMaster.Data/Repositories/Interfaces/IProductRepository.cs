using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Domain.Entities;

namespace WarehouseMaster.Data.Repositories.Interfaces
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllByWarehouseIdAsync(int warehouseId);

        Task<bool> UpdateAsync(Product product);
    }
}
