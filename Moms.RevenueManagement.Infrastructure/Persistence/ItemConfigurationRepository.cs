using System;
using Moms.RevenueManagement.Core.Domain.Item;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class ItemConfigurationRepository:BaseRepository<ItemConfiguration,Guid>, IITemConfigurationRepository
    {
        public ItemConfigurationRepository(RevenueContext context):  base(context)
        {

        }
    }
}
