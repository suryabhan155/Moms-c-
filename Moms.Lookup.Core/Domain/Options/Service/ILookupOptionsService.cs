using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;

namespace Moms.Lookup.Core.Domain.Options.Service
{
    public interface ILookupOptionsService
    {
        Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> LoadAll();
       /* Task<(bool IsSuccess, LookupOption lookupOption, string ErrorMessage)> GetLookupOptions(Guid id);*/
        Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsById(Guid id);
        Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsByName(string name);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupOption(Guid id);
        Task<(bool IsSuccess,LookupOption lookupOption, string ErrorMEssage )> AddLookupOption(LookupOption lookupOption);
    }
}
