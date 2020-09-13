



using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            /*Add scoped items for repositories */
            /* services
                .AddScoped<IClinicRepository, ClinicRepository>();*/
            return services;
        }
    }
}
