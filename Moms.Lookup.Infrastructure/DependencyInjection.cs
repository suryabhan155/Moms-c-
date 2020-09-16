
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Infrastructure.Persistence;
using Moms.RegistrationManagement.Core.Application.Facilities.Commands;

namespace Moms.Lookup.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<LookupContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(LookupContext).Assembly.FullName)));

            /*services
                .AddScoped<IClinicRepository, ClinicRepository>();*/
            services
                .AddScoped<ILookupMasterRepository, LookupMasterRepository>();
            services
                .AddScoped<ILookupItemRepository, LookupItemRepository>();
            services
                .AddScoped<ILookupOptionsRepository, LookupOptionsRepository>();

            return services;
        }
    }
}
