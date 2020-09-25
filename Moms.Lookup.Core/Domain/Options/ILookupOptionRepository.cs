using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain.Options
{
    public interface ILookupOptionRepository:IRepository<LookupOption,Guid>
    {
        Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> GetLookupOptionsById(Guid id);
        Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> GetLookupOptionsByName(string name);
    }
}
