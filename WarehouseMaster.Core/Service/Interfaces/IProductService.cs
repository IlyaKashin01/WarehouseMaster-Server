using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMaster.Core.DTO.Product;

namespace WarehouseMaster.Core.Service.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProductAsync(ProductRequest request);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<bool> IsExistProductAsync(int id);
    }
}
