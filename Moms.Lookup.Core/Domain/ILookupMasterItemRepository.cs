using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain
{
    public interface ILookupMasterItemRepository : IRepository<LookupMasterItem, Guid>
    {
       /* Task<(bool IsSuccess, IEnumerable<LookupOption>  lookupOption, ResponseModel model)> GetLookupOptionsByName(string name);
        Task<(bool IsSuccess, IEnumerable<LookupOption>  lookupOption, ResponseModel model)> GetLookupOptionsById(Guid id);*/
    }
}
