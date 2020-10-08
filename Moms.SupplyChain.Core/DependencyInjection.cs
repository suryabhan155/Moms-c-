using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Moms.SupplyChain.Core.Application.SupplyChain.Services;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;

namespace Moms.SupplyChain.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
           /* services.AddAutoMapper(typeof(BillingProfile));
            services.AddScoped<IBillingService, BillingService>();*/
           services
               .AddScoped<IStoreService, StoreService>();
               services
               .AddScoped<ISupplierService, SupplierService>();
               services
               .AddScoped<IPurchaseOrderService, PurchaseOrderService>();
               services
               .AddScoped<IPurchaseOrderItemService, PurchaseOrderItemService>();
               services
               .AddScoped<IGoodReceivedNoteService, GoodReceivedNoteService>();
               services
               .AddScoped<IGoodReceivedNoteItemService, GoodReceivedNoteItemService>();
               services
               .AddScoped<IStockVoucherService, StockVoucherService>();
               services
               .AddScoped<IStockVoucherItemService, StockVoucherItemService>();
               services
               .AddScoped<IStockAdjustmentService, StockAdjustmentService>();

            return services;
        }
    }
}
