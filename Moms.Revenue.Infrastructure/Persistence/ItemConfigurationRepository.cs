using System;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ItemConfigurationRepository:BaseRepository<ItemConfiguration,Guid>, IITemConfigurationRepository
    {
        public ItemConfigurationRepository(RevenueContext context):  base(context)
        {

        }
    }
}
