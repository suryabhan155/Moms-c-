using System;
using System.Reflection;
using Moms.SharedKernel.Interfaces.Persistence;
using Module = Moms.RevenueManagement.Core.Domain.Item.Models.Module;

namespace Moms.RevenueManagement.Core.Domain.Item
{
    public interface IModuleRepository:IRepository<Module, Guid>
    {

    }
}
