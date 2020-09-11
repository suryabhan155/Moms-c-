using System;
using Moms.RevenueManagement.Core.Domain.Item;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class ItemTypeSubTypeRepository:BaseRepository<ItemTypeSubType, Guid>, IITemTypeSubTypeRepository
    {
        public ItemTypeSubTypeRepository(RevenueContext context):base(context)
        {

        }
    }
}
