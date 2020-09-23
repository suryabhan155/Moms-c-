using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moms.Lookup.Core.Application.ICD.Services;
using Moms.RegistrationManagement.Core.Application.Facilities.Commands;
using Moms.RegistrationManagement.Core.Application.Patient.Services;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;

namespace Moms.RegistrationManagement.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            services.AddAutoMapper(typeof(FacilitiesProfile));
            services.AddAutoMapper(typeof(PatientProfile));
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDeathService, DeathService>();
            services.AddScoped<IEmployeeService, EmployerService>();
            services.AddScoped<IGuardianService, GuardianService>();

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
