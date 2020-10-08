using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupMasterItemService
    {
        Task<(bool IsSuccess, IEnumerable<LookupMasterItem> lookupMasterItems, string ErrorMessage)> LoadAll();
       /* Task<(bool IsSuccess, LookupOption lookupOption, string ErrorMessage)> GetLookupOptions(Guid id);*/
       /* Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsById(Guid id);
        Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsByName(string name);*/
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupOption(Guid id);
        Task<(bool IsSuccess,LookupMasterItem lookupOption, string ErrorMEssage )> AddLookupMasterItem(LookupMasterItem lookupOption);

        /* county option tools */
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetAllCounty();
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetCounty(string name);
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetSubCounty(string name);
        Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetWards(string name);
    }
}
