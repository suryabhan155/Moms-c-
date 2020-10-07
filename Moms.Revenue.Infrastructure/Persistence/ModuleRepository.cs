using System;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ModuleRepository:BaseRepository<Module, Guid>, IModuleRepository
    {
        public ModuleRepository(RevenueContext context):base(context)
        {

        }
    }
}
