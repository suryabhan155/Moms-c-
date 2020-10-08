using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Serilog;

namespace Moms.Lookup.Core.Application.Options.Service
{
    public class LookupMasterItemServices: ILookupMasterItemService
    {
        private readonly ILookupMasterItemRepository _lookupOptionsRepository;
        private readonly ILookupItemRepository _lookupItemRepository;
        private readonly ILookupMasterRepository _lookupMasterRepository;
        private readonly ICountyLookupRepository _countyLookupRepository;

        public LookupMasterItemServices(ILookupMasterItemRepository lookupOptionsRepository, ILookupItemRepository lookupItemRepository,
            ILookupMasterRepository lookupMasterRepository, ICountyLookupRepository countyLookupRepository)
        {
            _lookupOptionsRepository = lookupOptionsRepository;
            _lookupMasterRepository = lookupMasterRepository;
            _lookupItemRepository = lookupItemRepository;
            _countyLookupRepository = countyLookupRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupMasterItem> lookupMasterItems, string ErrorMessage)> LoadAll()
        {
            try
            {
                var data = await _lookupOptionsRepository.GetAll().ToListAsync();
                return (true, data, "LookupOptions loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading lookupOptions : Error occured",e);
                IEnumerable<LookupMasterItem>  lookupOption=new List<LookupMasterItem>();
                return (false, lookupOption, e.Message);
            }
        }

      /*  public async Task<(bool IsSuccess, IEnumerable<LookupOptionsDto>  lookupOptionsDtos, string ErrorMessage)> GetLookupOptionsById(Guid id)
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
                        LookupMaster=lookupOption.LookupMaster.Name,
                        LookupMasterAlias = lookupOption.LookupMaster.Alias,
                        LookupItemId=lookupOption.LookupItem.Id,
                        LookupItem=lookupOption.LookupItem.Name,
                        LookupItemAlias = lookupOption.LookupItem.Alias
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
        }*/

       /* public async Task<(bool IsSuccess, IEnumerable<LookupOptionsDto> lookupOptionsDtos , string ErrorMessage)> GetLookupOptionsByName(string name)
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
                        LookupMaster=lookupOption.LookupMaster.Name,
                        LookupMasterAlias = lookupOption.LookupMaster.Alias,
                        LookupItemId=lookupOption.LookupItem.Id,
                        LookupItem=lookupOption.LookupItem.Name,
                        LookupItemAlias = lookupOption.LookupItem.Alias
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
        }*/

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

        public async Task<(bool IsSuccess, LookupMasterItem lookupOption, string ErrorMEssage)> AddLookupMasterItem(LookupMasterItem lookupOption)
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

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetAllCounty()
        {
            try
            {
                var result = await _countyLookupRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<CountyLookup>(), "Counties Not Found") : (true, result, "Counties Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Adding LookupOptions : Error occured",e);
                return (false,new List<CountyLookup>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetCounty(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.CountyName == name.ToUpper())
                    .ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), "County not found");
                return (true, result, "county loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading County : Error occured",e);
                return (false,new List<CountyLookup>() , e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetSubCounty(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.SubCountyName == name.ToUpper())
                    .ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), "Error in loading SubCounty");
                return (true, result, "SubCounty loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading County : Error occured",e);
                return (false,new List<CountyLookup>() , e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, string ErrorMessage)> GetWards(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.WardName == name.ToUpper()).ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), "No Wards Found");
                return (true, result, "Wards Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Wards : Error occured",e);
                return (false,new List<CountyLookup>() , e.Message);
            }
        }
    }
}
