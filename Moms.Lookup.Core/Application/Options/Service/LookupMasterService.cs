using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Serilog;

namespace Moms.Lookup.Core.Application.Options.Service
{
    public class LookupMasterService:ILookupMasterService
    {
        private readonly ILookupMasterRepository _lookupMasterRepository;

        public LookupMasterService(ILookupMasterRepository lookupMasterRepository)
        {
            _lookupMasterRepository = lookupMasterRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<LookupMaster> lookupMasters, string ErrorMessage)> LoadAll()
        {
            try
            {
                var data =await  _lookupMasterRepository.GetAll(x => !x.Void).ToListAsync();
                return (true, data, "LookupMaster loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                IEnumerable<LookupMaster>  lookupMasters=new List<LookupMaster>();
                return (false, lookupMasters, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, string ErrorMessage)> GetLookupMaster(Guid id)
        {
            try
            {
                var data = await _lookupMasterRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                return (true, data, "Lookup Master Item loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
               LookupMaster lookupMaster=new LookupMaster("");
                return (false, lookupMaster, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, string ErrorMessage)> GetLookupMasterByName(string name)
        {
            try
            {
                var data = await _lookupMasterRepository.GetAll(x => x.Name == name).FirstOrDefaultAsync();
                return (true, data, "LookupMaster loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                LookupMaster lookupMaster=new LookupMaster("");
                return (false, lookupMaster, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupMaster(Guid id)
        {
            try
            {
                  _lookupMasterRepository.DeleteById(id);
                  await _lookupMasterRepository.Save();
                 return (true, id, "LookupMaster deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                return (false, id, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, string ErrorMEssage)> AddLookupMaster(LookupMaster lookupMaster)
        {
            try
            {
                _lookupMasterRepository.Create(lookupMaster);
                await _lookupMasterRepository.Save();
                return (true, lookupMaster, "LookupMaster Saved Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Lookup Master Saving: Error occured",e);
                return (false, lookupMaster, e.Message);
            }
        }
    }
}
