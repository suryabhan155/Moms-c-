using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ModuleService:IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
        public async Task<(bool IsSuccess, Module module, string ErrorMessage)> Create(Module module)
        {
            try
            {
                if(module.Id.IsNullOrEmpty())
                    _moduleRepository.Create(module);
                _moduleRepository.Update(module);
                await _moduleRepository.Save();
                return (true, module, "Module saved");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving module",e.Message);
                return(false,module,e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Module> module, string ErrorMessage)> GetAllModule()
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => !x.Void)
                    .Include(x=>x.PriceList)
                    .Include(x=>x.ClientBillPayments)
                    .ToListAsync();
                return result.Count > 0 ? (true, result, "Module(s) Loaded") : (false, result, "No Module(s) Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading module(s)",e.Message);
                return(false,new List<Module>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Module module, string ErrorMessage)> GetModule(Guid Id)
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => x.Id == Id)
                    .Include(x=>x.PriceList)
                    .Include(x=>x.ClientBillPayments)
                    .FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, result, "Module Not Found") : (true, result, "Module Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading module(s)",e.Message);
                return(false,new Module(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _moduleRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Module Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _moduleRepository.Save();
                return (true, Id, "Module Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error in Deleting module(s)",e.Message);
                return(false,Id, e.Message);
            }
        }
    }
}
