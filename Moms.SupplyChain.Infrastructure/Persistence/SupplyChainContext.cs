using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.SupplyChain.Infrastructure.Persistence
{
    public class SupplyChainContext:BaseContext
    {
        public SupplyChainContext(DbContextOptions<SupplyChainContext> options):base(options)
        {

        }

        public override void EnsureSeeded()
        {
            // For complex data use Pipes e.g SeedDataReader.ReadCsv<Clinic>(typeof(RegistrationContext).Assembly, "Seed", "|");
            SaveChanges();
        }
    }
}
