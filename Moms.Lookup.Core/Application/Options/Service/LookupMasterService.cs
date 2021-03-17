using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Interfaces.Persistence;
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


        public async Task<(bool IsSuccess, IEnumerable<LookupMaster> lookupMasters, ResponseModel model)> LoadAll()
        {
            try
            {
                var data =_lookupMasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC);
                //var data =await  _lookupMasterRepository.GetAll(x => !x.Void).ToListAsync();
                return (true, data, new ResponseModel { message = "LookupMaster loaded successfully", data = data, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                IEnumerable<LookupMaster>  lookupMasters=new List<LookupMaster>();
                return (false, lookupMasters, new ResponseModel { message = e.Message, data = lookupMasters, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, ResponseModel model)> GetLookupMaster(Guid id)
        {
            try
            {
                var data = await _lookupMasterRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                return (true, data, new ResponseModel { message = "Lookup Master Item loaded successfully", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
               LookupMaster lookupMaster=new LookupMaster();
                return (false, lookupMaster, new ResponseModel { message = e.Message, data = lookupMaster, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, ResponseModel model)> GetLookupMasterByName(string name)
        {
            try
            {
                var data = await _lookupMasterRepository.GetAll(x => x.Name == name).FirstOrDefaultAsync();
                return (true, data, new ResponseModel { message = "LookupMaster loaded Successfully", data = data, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                LookupMaster lookupMaster=new LookupMaster();
                return (false, lookupMaster, new ResponseModel { message = e.Message, data = lookupMaster, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteLookupMaster(Guid id)
        {
            try
            {
                  _lookupMasterRepository.DeleteById(id);
                  await _lookupMasterRepository.Save();
                 return (true, id, new ResponseModel { message = "LookupMaster deleted Successfully", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, LookupMaster lookupMaster, ResponseModel model)> AddLookupMaster(LookupMaster lookupMaster)
        {
            try
            {
                if (lookupMaster.Id.IsNullOrEmpty())
                    _lookupMasterRepository.Create(lookupMaster);
                else
                    _lookupMasterRepository.Update(lookupMaster);
                await _lookupMasterRepository.Save();
                return (true, lookupMaster,new ResponseModel {message = "LookupMaster Saved Successfully" ,data = lookupMaster, code = HttpStatusCode.OK } );
            }
            catch (Exception e)
            {
                Log.Error("Lookup Master Saving: Error occured",e);
                return (false, lookupMaster, new ResponseModel { message = e.Message, data = lookupMaster, code = HttpStatusCode.BadRequest });
            }
        }
    }
}
