using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IModuleService
    {
        Task<(bool IsSuccess, Module module, ResponseModel model)> Create(Module module);
        Task<(bool IsSuccess, IEnumerable<Module> module, ResponseModel model)> GetAllModule();
        Task<(bool IsSuccess, Module module, ResponseModel model)> GetModule(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
