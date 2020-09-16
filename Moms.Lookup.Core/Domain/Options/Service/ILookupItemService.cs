using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupItemService
    {
        Task<(bool IsSuccess, IEnumerable<LookupItem> lookupItem, string ErrorMessage)> LoadAll();
        Task<(bool IsSuccess, LookupItem lookupItem, string ErrorMessage)> GetLookupItem(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupItem(Guid id);
        Task<(bool IsSuccess,LookupItem lookupItem, string ErrorMEssage )> AddLookupItem(LookupItem lookupItem);
    }
}
