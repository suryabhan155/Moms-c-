using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Application.Options.Response;
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

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, ResponseModel model)> GetLookupOptionsById(Guid id)
        {
            try
            {
                var results = await GetAll(x => x.LookupMasterId == id).ToListAsync();
                return (true, results, new ResponseModel { message = "data fetched successfully", data = results, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupOptions Loading : Error occured",e);
                return (false, new List<LookupOption>(), new ResponseModel { message = e.Message, data = new List<LookupOption>(), code = HttpStatusCode.InternalServerError });
            }
        }
        

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, ResponseModel model)> GetLookupOptionsByName(string name)
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
                return (true, result,new ResponseModel { message = "data fetched successfully", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupOptionsByName Loading : Error occured", e);
                return (false, new List<LookupOption>(), new ResponseModel { message = e.Message, data = new List<LookupOption>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
