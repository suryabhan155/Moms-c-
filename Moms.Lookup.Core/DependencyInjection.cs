using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moms.Lookup.Core.Application.Options.Service;
using Moms.Lookup.Core.Domain.Options.Service;

namespace Moms.Lookup.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            // services.AddAutoMapper(typeof(FacilitiesProfile));
            // services.AddAutoMapper(typeof(PatientProfile));
            services.AddScoped<ILookupMasterService, LookupMasterService>();
            services.AddScoped<ILookupItemService, LookupItemService>();
            services.AddScoped<ILookupOptionsService, LookupOptionsServices>();

         /*   if (null != others)
            {
                others.Add(typeof(SampleCommandHandler).Assembly);
                services.AddMediatR(others.ToArray());
            }
            else
            {
                services.AddMediatR(typeof(SampleCommandHandler).Assembly);
            }*/

            return services;
        }
    }
}
