using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moms.RevenueManagement.Core.Application.Billing.Services;
using Moms.RevenueManagement.Core.Domain.Billing;
using Moms.RevenueManagement.Core.Domain.Billing.Dto;

namespace Moms.RevenueManagement.Core
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
