using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.RevenueManagement.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SharedKernel.Utility;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class RevenueContext : BaseContext
    {
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public RevenueContext(DbContextOptions<RevenueContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override void EnsureSeeded()
        {
            // For complex data use Pipes e.g SeedDataReader.ReadCsv<Clinic>(typeof(RegistrationContext).Assembly, "Seed", "|");

            if (!PaymentTypes.Any())
            {
                var data = SeedDataReader.ReadCsv<PaymentType>(typeof(RevenueContext).Assembly);
                AddRange(data);
            }

            SaveChanges();
        }
    }
}
