using System;
using Moms.RevenueManagement.Core.Domain.Item;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class ItemMasterRepository:BaseRepository<ItemMaster, Guid>, IItemMasterRepository
    {
        public ItemMasterRepository(RevenueContext context): base(context)
        {

        }
    }
}
