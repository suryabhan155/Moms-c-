using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ModuleService:IModuleService
    {
        public Task<(bool IsSuccess, Module module, string ErrorMessage)> Create(Module module)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<Module> module, string ErrorMessage)> GetAllModule()
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Module module, string ErrorMessage)> GetModule(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
