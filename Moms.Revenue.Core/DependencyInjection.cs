using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moms.Revenue.Core.Application.Billing.Services;
using Moms.Revenue.Core.Application.Item.Service;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Dto;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.Revenue.Core.Domain.Item.Services;

namespace Moms.Revenue.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            services.AddAutoMapper(typeof(BillingProfile));
            services.AddScoped<IBillingDiscountService, BillingDiscountService>();
            services.AddScoped<IBillingTypeService, BillingTypeService>();
            services.AddScoped<IBillingMasterService, BillingMasterService>();
            services.AddScoped<IBillingItemTypeService, BillingItemTypeService>();
            services.AddScoped<IBillingItemConfigurationService, BillingItemConfigurationService>();
            services.AddScoped<IBillingItemMasterService, BillingItemMasterService>();
            services.AddScoped<IBillingSubItemTypeService, BillingSubItemTypeService>();
            services.AddScoped<IPaymentMasterService, PaymentMasterService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IClientBillingItemService, ClientBillingItemService>();
            //services.AddScoped<IClientBillingService, ClientBillingService>();
            services.AddScoped<IClientBillingService, ClientBillingService>();
            services.AddScoped<IClientBillPaymentService, ClientBillPaymentService>();
            services.AddScoped<IPriceListService, PriceListService>();
            services.AddScoped<IPriceMasterService, PriceMasterService>();

            services.AddScoped<IItemConfigurationService, ItemConfigurationService>();
            services.AddScoped<Domain.Item.Services.IItemMasterService, ItemMasterService>();
            services.AddScoped<IItemTypeService, ItemTypeService>();
            services.AddScoped<IItemTypeSubTypeService, ItemTypeSubTypeService>();
            services.AddScoped<IModuleService, ModuleService>();
            return services;
        }
    }
}
