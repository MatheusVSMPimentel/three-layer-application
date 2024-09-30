using App.BusinessLayer.Interfaces.Repositories;
using App.BusinessLayer.Interfaces.Services;
using App.BusinessLayer.Notifications;
using App.BusinessLayer.Services;
using App.DataLayer.Context;
using App.DataLayer.Repositories;

namespace App.Api.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<MsSQLServerContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Business
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<INotifier, Notifier>();


            return services;
        }
    }
}
