using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moms.Clinical.Core.Application.Consultation.Commands;
using Moms.Clinical.Core.Application.Consultation.Services;
using Moms.Clinical.Core.Domain.Consultation.Services;

namespace Moms.Clinical.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, List<Assembly> others = null)
        {
            // Add scoped resources
            services.AddScoped<IConsultationComplaintService, ConsultationComplaintService>();
            services.AddScoped<IConsultationDiagnosisService, ConsultationDiagnosisService>();
            services.AddScoped<IConsultationFindingService, ConsultationFindingService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped<IConsultationServiceService, ConsultationServiceService>();
            services.AddScoped<IConsultationTreatmentService, ConsultationTreatmentService>();
            services.AddScoped<IVitalsService, VitalsService>();

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
