using System;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ClientBillingItemRepository:BaseRepository<ClientBillingItem, Guid>,IClientBillingItemRepository
    {
        public ClientBillingItemRepository(RevenueContext context) : base(context)
        {
        }
    }
}
