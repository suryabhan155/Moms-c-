

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SharedKernel.Utility;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupContext: BaseContext
    {
        public DbSet<LookupMaster> LookupMasters { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<LookupOption> LookupOptions { get; set; }
        public DbSet<IcdCodeChapter> IcdCodeChapters { get; set; }
        public DbSet<IcdCodeBlock> IcdCodeBlocks { get; set; }
        public DbSet<IcdCodeSubBlock> IcdCodeSubBlocks { get; set; }
        public DbSet<IcdCode> IcdCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupOption>()
                .HasOne(p => p.lookupMater)
                .WithMany(b=>b.LookupOption)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LookupOption>()
                .HasOne(p => p.lookupItem)
                .WithMany(i => i.lookupOptions)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public LookupContext(DbContextOptions<LookupContext> options) : base(options)
        {
        }

        public override void EnsureSeeded()
        {
            /*  add seeding of models here */
            if (!LookupMasters.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupMaster>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!LookupItems.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupItem>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

          /*  if (!LookupOptions.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupOption>(typeof(LookupContext).Assembly);
                AddRange(data);
            }*/
            SaveChanges();
        }
    }
}
