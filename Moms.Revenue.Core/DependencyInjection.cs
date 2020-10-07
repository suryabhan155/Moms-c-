using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moms.Revenue.Core.Application.Billing.Services;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Dto;
using Moms.Revenue.Core.Domain.Billing.Services;

namespace Moms.Revenue.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            services.AddAutoMapper(typeof(BillingProfile));
            services.AddScoped<IBillingService, BillingService>();

            return services;
        }
    }
}
