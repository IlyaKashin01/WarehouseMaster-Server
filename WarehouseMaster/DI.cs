using WarehouseMaster.Core.Service.Impl;
using WarehouseMaster.Core.Service.Interfaces;
using WarehouseMaster.Data.Repositories.Impl;
using WarehouseMaster.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace WarehouseMaster
{
    public static class DI
    {
        public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
        {
            return services
                .AddScoped<IStafferRepository, StafferRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IWarehouseRepository, WarehouseRepository>()
                .AddScoped<IEntranceRepository, EntranceRepository>()
                .AddScoped<IShipmentRepository, ShipmentRepository>()
                .AddScoped<IProviderRepository, ProviderRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }

        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            return services
                .AddScoped<IStafferService, StafferService>()
                .AddScoped<IWarehouseService, WarehouseService>()
                .AddScoped<IEntranceService, EntranceService>()
                .AddScoped<IShipmentService, ShipmentService>()
                .AddScoped<IProviderService, ProviderService>()
                .AddScoped<IProductService, ProductService>();
        }
    }
}
