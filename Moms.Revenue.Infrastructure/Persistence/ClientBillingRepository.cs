using System;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class ClientBillingRepository:BaseRepository<ClientBill, Guid>, IClientBillRepository
    {
        public ClientBillingRepository(RevenueContext context) : base(context)
        {
        }
    }
}
