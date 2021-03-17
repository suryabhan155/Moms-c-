using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.Laboratory.Infrastructure.Persistence;

namespace Moms.Laboratory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<LaboratoryContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(LaboratoryContext).Assembly.FullName)));

            /*services
                .AddScoped<IClinicRepository, ClinicRepository>();*/
            return services;
        }
    }
}
