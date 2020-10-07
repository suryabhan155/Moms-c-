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
               .AddScoped<IStoreService, StoreService>()
               .AddScoped<ISupplierService, SupplierService>()
               .AddScoped<IPurchaseOrderService, PurchaseOrderService>()
               .AddScoped<IPurchaseOrderItemService, PurchaseOrderItemService>()
               .AddScoped<IGoodReceivedNoteService, GoodReceivedNoteService>()
               .AddScoped<IGoodReceivedNoteItemService, GoodReceivedNoteItemService>()
               .AddScoped<IStockVoucherService, StockVoucherService>()
               .AddScoped<IStockVoucherItemService, StockVoucherItemService>()
               .AddScoped<IStockAdjustmentService, StockAdjustmentService>();

            return services;
        }
    }
}
