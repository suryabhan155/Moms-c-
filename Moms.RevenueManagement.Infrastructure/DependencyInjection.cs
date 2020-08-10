using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moms.RevenueManagement.Core.Domain.Billing;
using Moms.RevenueManagement.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<RevenueContext>(o => o.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"), x =>
                        x.MigrationsAssembly(typeof(RevenueContext).Assembly.FullName)));

            services
                .AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            return services;
        }
    }
}
