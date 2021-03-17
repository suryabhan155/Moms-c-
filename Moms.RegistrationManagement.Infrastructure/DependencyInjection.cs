using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Infrastructure.Persistence;

namespace Moms.RegistrationManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                 services.AddDbContext<RegistrationContext>(o => o.UseNpgsql(
                     configuration.GetConnectionString("DatabaseConnection"), x =>
                         x.MigrationsAssembly(typeof(RegistrationContext).Assembly.FullName)));

            services
                .AddScoped<IClinicRepository, ClinicRepository>();
            services
                .AddScoped<IPatientRepository, PatientRepository>();
            services
                .AddScoped<IContactRepository, ContactRepository>();
            services
                .AddScoped<IGuardianRepository, GuardianRepository>();
            services
                .AddScoped<IEmployerRepository, EmployerRepository>();
            services
                .AddScoped<IDeathRepository, DeathRepository>();

            services.AddScoped<IPatientGridRepository, PatientGridRepository>();
            return services;
        }
    }
}
