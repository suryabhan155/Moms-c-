using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupItemService
    {
        Task<(bool IsSuccess, IEnumerable<LookupItem> lookupItem, ResponseModel ErrorMessage)> LoadAll();
        Task<(bool IsSuccess, LookupItem lookupItem, ResponseModel ErrorMessage)> GetLookupItem(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel ErrorMessage)> DeleteLookupItem(Guid id);
        Task<(bool IsSuccess,LookupItem lookupItem, ResponseModel ErrorMessage )> AddLookupItem(LookupItem lookupItem);
    }
}
