using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.SupplyChain.Infrastructure.Persistence;

namespace Moms.SupplyChain.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<SupplyChainContext>(o => o.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(SupplyChainContext).Assembly.FullName)));

            /* services
                 .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();*/
            return services;
        }
    }
}
