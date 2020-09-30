using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.Clinical.Infrastructure.Persistence;

namespace Moms.Clinical.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<ClinicalContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(ClinicalContext).Assembly.FullName)));

            services.AddScoped<IConsultationComplaintRepository, ConsultationComplaintRepository>();
            services.AddScoped<IConsultationDiagnosisRepository, ConsultationDiagnosisRepository>();
            services.AddScoped<IConsultationFindingRepository, ConsultationFindingRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            services.AddScoped<IConsultationServiceRepository, ConsultationServiceRepository>();
            services.AddScoped<IConsultationTreatmentRepository, ConsultationTreatmentRepository>();
            services.AddScoped<IVitalsRepository, VitalsRepository>();
            services.AddScoped<IConsultationServiceRepository, ConsultationServiceRepository>();
            return services;
        }
    }
}
