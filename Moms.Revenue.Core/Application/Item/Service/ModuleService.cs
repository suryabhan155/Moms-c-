using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;
using Moms.SharedKernel.Response;
using System.Net;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ModuleService:IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
        public async Task<(bool IsSuccess, Module module, ResponseModel model)> Create(Module module)
        {
            try
            {
                if(module.Id.IsNullOrEmpty())
                    _moduleRepository.Create(module);
                _moduleRepository.Update(module);
                await _moduleRepository.Save();
                return (true, module, new ResponseModel { message = "Module saved", data = module , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving module",e.Message);
                return(false,module, new ResponseModel { message = e.Message, data = module , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Module> module, ResponseModel model)> GetAllModule()
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => !x.Void)
                    .Include(x=>x.PriceList)
                    .Include(x=>x.ClientBillPayments)
                    .ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Module(s) Loaded", data = result , code = HttpStatusCode.OK }) : (false, result, new ResponseModel { message = "No Module(s) Found", data = result , code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading module(s)",e.Message);
                return(false,new List<Module>(), new ResponseModel { message = e.Message, data = new List<Module>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Module module, ResponseModel model)> GetModule(Guid Id)
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => x.Id == Id)
                    .Include(x=>x.PriceList)
                    .Include(x=>x.ClientBillPayments)
                    .FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, result, new ResponseModel { message = "Module Not Found", data = result , code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Module Loaded", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading module(s)",e.Message);
                return(false,new Module(), new ResponseModel { message = e.Message, data = new Module(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Module Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _moduleRepository.Save();
                return (true, Id, new ResponseModel { message = "Module Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Deleting module(s)",e.Message);
                return(false,Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
