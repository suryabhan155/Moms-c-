using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SharedKernel.Utility;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class RevenueContext : BaseContext
    {
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<BillingDiscount> BillingDiscounts { get; set; }
        public DbSet<BillingType> BillingTypes { get; set; }
        public DbSet<BillingMaster> BillingMasters { get; set; }
        public DbSet<BillingItemType> BillingItemTypes { get; set; }
        public DbSet<BillingItemMaster> BillingItemMasters { get; set; }
        public DbSet<BillingItemConfiguration> BillingItemConfigurations { get; set; }
        public DbSet<BillingSubItemType> BillingSubItemTypes { get; set; }
        public DbSet<PaymentMaster> PaymentMasters { get; set; }
        public DbSet<ClientBill> ClientBills { get; set; }
        public DbSet<ClientBillingItem> ClientBillingItems { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<PriceMaster> PriceMasters { get; set; }

        /* Item Configuration Models*/
        public DbSet<ItemConfiguration> ItemConfigurations { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemTypeSubType> ItemTypeSubTypes { get; set; }
        public DbSet<Module> Modules { get; set; }

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


            if (!Modules.Any())
            {
                var data = SeedDataReader.ReadCsv<Module>(typeof(RevenueContext).Assembly);
                AddRange(data);
            }

            if (!ItemTypes.Any())
            {
                var data = SeedDataReader.ReadCsv<ItemType>(typeof(RevenueContext).Assembly);
                AddRange(data);
            }

            if (!ItemTypeSubTypes.Any())
            {
                var data = SeedDataReader.ReadCsv<ItemTypeSubType>(typeof(RevenueContext).Assembly);
                AddRange(data);
            }

            if (!ItemMasters.Any())
            {
                var data = SeedDataReader.ReadCsv<ItemMaster>(typeof(RevenueContext).Assembly);
                AddRange(data);
            }

            SaveChanges();
        }
    }
}
