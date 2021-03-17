using System;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ItemTypeRepository:BaseRepository<ItemType, Guid>, IItemTypeRepository
    {
        public ItemTypeRepository(RevenueContext context):base(context)
        {

        }
    }
}
