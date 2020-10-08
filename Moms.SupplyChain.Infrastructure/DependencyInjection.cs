using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Moms.SupplyChain.Infrastructure.Persistence;

namespace Moms.SupplyChain.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<SupplyChainContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(SupplyChainContext).Assembly.FullName)));

            /* services
                 .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();*/
            services
                .AddScoped<IStoreRepository, StoreRepository>();
            services
                .AddScoped<ISupplierRepository, SupplierRepository>();
            services
                .AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services
                .AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
            services
                .AddScoped<IGoodReceivedNoteRepository, GoodReceivedNoteRepository>();
            services
                .AddScoped<IGoodReceivedNoteItemRepository, GoodReceivedNoteItemRepository>();
            services
                .AddScoped<IStockVoucherRepository, StockVoucherRepository>();
            services
                .AddScoped<IStockVoucherItemRepository, StockVoucherItemRepository>();
            services
                .AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();

            return services;
        }
    }
}
