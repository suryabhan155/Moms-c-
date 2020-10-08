using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<RevenueContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(RevenueContext).Assembly.FullName)));

            services
                .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IITemConfigurationRepository, ItemConfigurationRepository>();
            services
                .AddScoped<IItemMasterRepository, ItemMasterRepository>();
            services
                .AddScoped<IItemTypeRepository, ItemTypeRepository>();

            services
                .AddScoped<IITemTypeSubTypeRepository, ItemTypeSubTypeRepository>();
            services
                .AddScoped<IModuleRepository, ModuleRepository>();
            services
                .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

            return services;
        }
    }
}