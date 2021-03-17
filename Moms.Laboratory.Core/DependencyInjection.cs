using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Moms.Laboratory.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
           /* services.AddAutoMapper(typeof(FacilitiesProfile));
            services.AddAutoMapper(typeof(PatientProfile));
            services.AddScoped<IClinicService, ClinicService>();*/

          /*  if (null != others)
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
