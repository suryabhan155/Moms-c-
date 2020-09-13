using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moms.RegistrationManagement.Core.Application.Facilities.Commands;

namespace Moms.Clinical.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            // Add scoped resources

            if (null != others)
            {
                others.Add(typeof(SampleCommandHandler).Assembly);
                services.AddMediatR(others.ToArray());
            }
            else
            {
                services.AddMediatR(typeof(SampleCommandHandler).Assembly);
            }

            return services;
        }
    }
}
