using System;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ItemMasterRepository:BaseRepository<ItemMaster, Guid>, IItemMasterRepository
    {
        public ItemMasterRepository(RevenueContext context): base(context)
        {

        }
    }
}
