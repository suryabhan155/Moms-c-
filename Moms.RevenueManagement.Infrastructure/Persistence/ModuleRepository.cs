using System;
using Moms.RevenueManagement.Core.Domain.Item;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class ModuleRepository:BaseRepository<Module, Guid>, IModuleRepository
    {
        public ModuleRepository(RevenueContext context):base(context)
        {

        }
    }
}
