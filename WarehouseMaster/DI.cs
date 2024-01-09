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
            services.AddLogging(builder =>
             {
                 builder.AddConsole();
             });
            return services
                /*.AddLogging(builder =>
                {
                    builder.AddConsole();
                })*/
                .AddScoped<IStafferRepository, StafferRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ISubCategoryRepository, SubCategoryRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }

        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            /*services.AddLogging(builder =>
            {
                builder.AddConsole();
            });*/
            return services
                .AddLogging(builder =>
                {
                    builder.AddConsole(); 
                })
                .AddScoped<IStafferService, StafferService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<ISubCategoryService, SubCategoryService>()
                .AddScoped<IProductService, ProductService>();
        }
    }
}
