using System;
using Moms.RevenueManagement.Core.Domain.Item;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class ItemTypeRepository:BaseRepository<ItemType, Guid>, IItemTypeRepository
    {
        public ItemTypeRepository(RevenueContext context):base(context)
        {

        }
    }
}
