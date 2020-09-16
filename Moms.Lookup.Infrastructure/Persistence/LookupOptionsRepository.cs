using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Serilog;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupOptionsRepository: BaseRepository<LookupOption, Guid>, ILookupOptionsRepository
    {
        public LookupOptionsRepository(LookupContext context) : base(context)
        {
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOption, string ErrorMessage)> GetLookupOptionsByName(string name)
        {
            try
            {
                using (var ctx = Context as LookupContext)
                {
                    var data = await ctx.LookupOptions.Where(x => x.LookupName == name)
                        .Include(b => b.lookupMater)
                        .Include(i => i.lookupItem)
                        .ToListAsync();
                    if (data.Count > 0)
                        return (true, data, "LookupOptions loaded successfully");
                    return (false, new List<LookupOption>(), "LookupOptions not found");
                }
            }
            catch (Exception e)
            {
                Log.Error("LookupOptions Loading : Error occured",e);
                IEnumerable<LookupMaster>  lookupMasters=new List<LookupMaster>();
                return (false, new List<LookupOption>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOption, string ErrorMessage)> GetLookupOptionsById(Guid id)
        {
            var ctx = Context as LookupContext;

            var data = await ctx.LookupOptions.Where(x => x.LookupMasterId == id)
                .Include(b => b.lookupMater)
                .Include(i=>i.lookupItem)
                .ToListAsync();

                if (data.Count > 0)
                    return (true, data, "LookupOption Loaded successfully");
                return (false, new List<LookupOption>(), "LookupOption not found");
        }
    }
}
