using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Moms.SupplyChain.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
           /* services.AddAutoMapper(typeof(BillingProfile));
            services.AddScoped<IBillingService, BillingService>();*/

            return services;
        }
    }
}
