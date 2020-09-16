

using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

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

        public LookupContext(DbContextOptions<LookupContext> options) : base(options)
        {
        }

        public override void EnsureSeeded()
        {
            /*  add seeding of models here */
            SaveChanges();
        }
    }
}
