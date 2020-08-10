using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moms.RegistrationManagement.Core.Application.Facilities.Commands;
using Moms.RegistrationManagement.Core.Application.Facilities.Services;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;

namespace Moms.RegistrationManagement.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            services.AddAutoMapper(typeof(FacilitiesProfile));
            services.AddScoped<IClinicService, ClinicService>();

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
