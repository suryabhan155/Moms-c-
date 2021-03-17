using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupMasterItemService
    {
        Task<(bool IsSuccess, IEnumerable<LookupMasterItem> lookupMasterItems, ResponseModel model)> LoadAll();
       /* Task<(bool IsSuccess, LookupOption lookupOption, ResponseModel model)> GetLookupOptions(Guid id);*/
       /* Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, ResponseModel model)> GetLookupOptionsById(Guid id);
        Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, ResponseModel model)> GetLookupOptionsByName(string name);*/
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteLookupOption(Guid id);
        Task<(bool IsSuccess,LookupMasterItem lookupOption, ResponseModel model )> AddLookupMasterItem(LookupMasterItem lookupOption);

        /* county option tools */
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetAllCounty();
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetCounty(string name);
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetSubCounty(string name);
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetWards(string name);
    }
}
