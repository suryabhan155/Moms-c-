

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SharedKernel.Utility;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupContext: BaseContext
    {
        public DbSet<LookupMaster> LookupMasters { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<LookupMasterItem> LookupMasterItems { get; set; }
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

            if (!LookupItems.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupItem>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!LookupMasters.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupMaster>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!LookupMasterItems.Any())
            {
                var data = SeedDataReader.ReadCsv<LookupMasterItem>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!IcdCodeChapters.Any())
            {
                var data = SeedDataReader.ReadCsv<IcdCodeChapter>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

          /*  if (!IcdCodeBlocks.Any())
            {
                var data = SeedDataReader.ReadCsv<IcdCodeBlock>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!IcdCodeSubBlocks.Any())
            {
                var data = SeedDataReader.ReadCsv<IcdCodeSubBlock>(typeof(LookupContext).Assembly);
                AddRange(data);
            }

            if (!IcdCodes.Any())
            {
                var data = SeedDataReader.ReadCsv<IcdCode>(typeof(LookupContext).Assembly);
                AddRange(data);
            }*/

            SaveChanges();
        }
    }
}
