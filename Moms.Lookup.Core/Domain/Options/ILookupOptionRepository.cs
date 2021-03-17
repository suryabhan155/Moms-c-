using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain.Options
{
    public interface ILookupOptionRepository:IRepository<LookupOption,Guid>
    {
        Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, ResponseModel model)> GetLookupOptionsById(Guid id);
        Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, ResponseModel model)> GetLookupOptionsByName(string name);
    }
}
