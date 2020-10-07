using System;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ItemTypeSubTypeRepository:BaseRepository<ItemTypeSubType, Guid>, IITemTypeSubTypeRepository
    {
        public ItemTypeSubTypeRepository(RevenueContext context):base(context)
        {

        }
    }
}
