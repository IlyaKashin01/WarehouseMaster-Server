using ProductService.Data.Repositories.Interfaces;
using WarehouseMaster.Common.Repositories;
using WarehouseMaster.Data;
using WarehouseMaster.Domain.Entities;

namespace ProductService.Data.Repositories.Impl
{
    public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository;
}
