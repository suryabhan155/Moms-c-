using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Serilog;

namespace Moms.Lookup.Core.Application.Options.Service
{
    public class LookupOptionsServices: ILookupOptionsService
    {
        private readonly ILookupOptionsRepository _lookupOptionsRepository;
        private readonly ILookupItemRepository _lookupItemRepository;
        private readonly ILookupMasterRepository _lookupMasterRepository;

        public LookupOptionsServices(ILookupOptionsRepository lookupOptionsRepository, ILookupItemRepository lookupItemRepository, ILookupMasterRepository lookupMasterRepository)
        {
            _lookupOptionsRepository = lookupOptionsRepository;
            _lookupMasterRepository = lookupMasterRepository;
            _lookupItemRepository = lookupItemRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOption> lookupOptions, string ErrorMessage)> LoadAll()
        {
            try
            {
                var data = await _lookupOptionsRepository.GetAll().ToListAsync();
                return (true, data, "LookupOptions loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading lookupOptions : Error occured",e);
                IEnumerable<LookupOption>  lookupOption=new List<LookupOption>();
                return (false, lookupOption, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOptionsDto>  lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsById(Guid id)
        {
            try
            {
                var data = await _lookupOptionsRepository.GetLookupOptionsById(id);
                if (!data.IsSuccess)
                    return (false, new List<LookupOptionsDto>(), data.ErrorMessage);
                var lookupOptions = data.lookupOption;
                List<LookupOptionsDto> lookupOptionsDtos=new List<LookupOptionsDto>();
                foreach (var lookupOption in lookupOptions)
                {
                    LookupOptionsDto lookupOptionsDto=new LookupOptionsDto()
                    {
                        Id = lookupOption.Id,
                        LookupName=lookupOption.LookupName,
                        LookupNameAlias=lookupOption.LookupNameAlias,
                        LookupMasterId=lookupOption.LookupMasterId,
                        LookupMaster=lookupOption.lookupMater.Name,
                        LookupMasterAlias = lookupOption.lookupMater.Alias,
                        LookupItemId=lookupOption.lookupItem.Id,
                        LookupItem=lookupOption.lookupItem.Name,
                        LookupItemAlias = lookupOption.lookupItem.Alias
                    };
                    lookupOptionsDtos.Add(lookupOptionsDto);
                }

                return (true, lookupOptionsDtos, "Successfully loaded the LookupOptions");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading lookupOptions : Error occured",e);
               IEnumerable<LookupOptionsDto>  lookupOptionsDtos=new List<LookupOptionsDto>();
                return (false, lookupOptionsDtos, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos , string ErrorMessage)> GetLookupOptionsByName(string name)
        {
            try
            {
                var data = await _lookupOptionsRepository.GetLookupOptionsByName(name);
                if (!data.IsSuccess)
                    return (false, new List<LookupOptionsDto>(), data.ErrorMessage);
                var lookupOptions = data.lookupOption;
                List<LookupOptionsDto> lookupOptionsDtos=new List<LookupOptionsDto>();

                foreach (var lookupOption in lookupOptions)
                {
                    LookupOptionsDto lookupOptionsDto=new LookupOptionsDto()
                    {
                        Id = lookupOption.Id,
                        LookupName=lookupOption.LookupName,
                        LookupNameAlias=lookupOption.LookupNameAlias,
                        LookupMasterId=lookupOption.LookupMasterId,
                        LookupMaster=lookupOption.lookupMater.Name,
                        LookupMasterAlias = lookupOption.lookupMater.Alias,
                        LookupItemId=lookupOption.lookupItem.Id,
                        LookupItem=lookupOption.lookupItem.Name,
                        LookupItemAlias = lookupOption.lookupItem.Alias
                    };
                    lookupOptionsDtos.Add(lookupOptionsDto);
                }
                return (true, lookupOptionsDtos, "Lookup Option Loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading lookupOptions : Error occured",e);
               IEnumerable<LookupOptionsDto>  lookupOption=new List<LookupOptionsDto>();
                return (false, lookupOption, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupOption(Guid id)
        {
            try
            {
                _lookupOptionsRepository.DeleteById(id);
                await _lookupOptionsRepository.Save();
                return (true, id, "LookupOption deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting lookupOptions : Error occured",e);
                return (false, id, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupOption lookupOption, string ErrorMEssage)> AddLookupOption(LookupOption lookupOption)
        {
            try
            {
               _lookupOptionsRepository.Create(lookupOption);
               await _lookupOptionsRepository.Save();
               return (true, lookupOption, "LookupOption added successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Adding LookupOptions : Error occured",e);
                return (false, lookupOption, e.Message);
            }
        }
    }
}
