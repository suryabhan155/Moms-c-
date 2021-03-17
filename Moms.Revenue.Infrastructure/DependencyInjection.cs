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

            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IITemConfigurationRepository, ItemConfigurationRepository>();
            services.AddScoped<IItemMasterRepository, ItemMasterRepository>();
            services.AddScoped<IItemTypeRepository, ItemTypeRepository>();

            services.AddScoped<IITemTypeSubTypeRepository, ItemTypeSubTypeRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

            services.AddScoped<IBillingDiscountRepository, BillingDiscountRepository>();
            services.AddScoped<IBillingTypeRepository, BillingTypeRepository>();
            services.AddScoped<IBillingMasterRepository, BillingMasterRepository>();
            services.AddScoped<IBillingItemMasterRepository, BillingItemMasterRepository>();
            services.AddScoped<IBillingItemConfigurationRepository, BillingItemConfigurationRepository>();
            services.AddScoped<IBillingItemTypeRepository, BillingItemTypeRepository>();
            services.AddScoped<IBillingSubItemTypeRepository, BillingSubItemTypeRepository>();
            services.AddScoped<IPaymentMasterRepository, PaymentMasterRepository>();
            services.AddScoped<IClientBillingItemRepository, ClientBillingItemRepository>();
            services.AddScoped<IClientBillRepository, ClientBillRepository>();
            //services.AddScoped<IClientBillRepository, ClientBillRepository>();
            services.AddScoped<IClientBilPaymentRepository, ClientBillPaymentRepository>();
            services.AddScoped<IPriceListRepository, PriceListRepository>();
            services.AddScoped<IPriceMasterRepository, PriceMasterRepository>();

            return services;
        }
    }
}
