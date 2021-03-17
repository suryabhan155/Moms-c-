using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Infrastructure.Persistence
{
    public class SupplyChainContext:BaseContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<GoodReceivedNote> GoodReceivedNotes { get; set; }
        public DbSet<GoodReceivedNoteItem> GoodReceivedNoteItems { get; set; }
        public DbSet<StockVoucher> StockVouchers { get; set; }
        public DbSet<StockVoucherIssue> StockVoucherIssues { get; set; }
        public DbSet<StockVoucherItem> StockVoucherItems { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockAdjustmentItem> StockAdjustmentItems { get; set; }

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
