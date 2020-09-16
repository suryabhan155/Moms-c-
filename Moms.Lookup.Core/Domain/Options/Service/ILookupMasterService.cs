using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupMasterService
    {
        Task<(bool IsSuccess, IEnumerable<LookupMaster> lookupMasters, string ErrorMessage)> LoadAll();
        Task<(bool IsSuccess, LookupMaster lookupMaster, string ErrorMessage)> GetLookupMaster(Guid id);
        Task<(bool IsSuccess, LookupMaster lookupMaster, string ErrorMessage)> GetLookupMasterByName(string name);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupMaster(Guid id);
        Task<(bool IsSuccess,LookupMaster lookupMaster, string ErrorMEssage )> AddLookupMaster(LookupMaster lookupMaster);
    }
}
