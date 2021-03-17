using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupMasterService
    {
        Task<(bool IsSuccess, IEnumerable<LookupMaster> lookupMasters, ResponseModel model)> LoadAll();
        Task<(bool IsSuccess, LookupMaster lookupMaster, ResponseModel model)> GetLookupMaster(Guid id);
        Task<(bool IsSuccess, LookupMaster lookupMaster, ResponseModel model)> GetLookupMasterByName(string name);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteLookupMaster(Guid id);
        Task<(bool IsSuccess,LookupMaster lookupMaster, ResponseModel model )> AddLookupMaster(LookupMaster lookupMaster);
    }
}
