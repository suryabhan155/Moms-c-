using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.Options;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Serilog;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupOptionRepository:BaseRepository<LookupOption,Guid>, ILookupOptionRepository
    {
        public LookupOptionRepository(LookupContext context) : base(context)
        {
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> GetLookupOptionsById(Guid id)
        {
            try
            {
                var results = await GetAll(x => x.LookupMasterId == id).ToListAsync();
                return (true, results, "data fetched successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupOptions Loading : Error occured",e);
                return (false, new List<LookupOption>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> GetLookupOptionsByName(string name)
        {
            try
            {
               /* var result = await GetAll(x => x.LookupMasterName == name)
                    .Select(x=>new
                    {
                        x.Id,
                        x.LookupMasterId,
                        x.LookupMasterName,
                        x.LookMasterAlias,
                        x.LookupItemId,
                        x.LookupItemName,
                        x.LookupItemAlias
                    }).ToListAsync();*/

               var result = await GetAll(x => x.LookupMasterName == name).ToListAsync();
                return (true, result, "data fetched successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
