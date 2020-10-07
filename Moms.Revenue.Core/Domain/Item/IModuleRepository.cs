using System;
using System.Reflection;
using Moms.SharedKernel.Interfaces.Persistence;
using Module = Moms.Revenue.Core.Domain.Item.Models.Module;


namespace Moms.Revenue.Core.Domain.Item
{
    public interface IModuleRepository:IRepository<Module, Guid>
    {

    }
}
