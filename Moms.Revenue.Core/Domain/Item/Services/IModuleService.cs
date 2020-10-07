using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IModuleService
    {
        Task<(bool IsSuccess, Module module, string ErrorMessage)> Create(Module module);
        Task<(bool IsSuccess, IEnumerable<Module> module, string ErrorMessage)> GetAllModule();
        Task<(bool IsSuccess, Module module, string ErrorMessage)> GetModule(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
