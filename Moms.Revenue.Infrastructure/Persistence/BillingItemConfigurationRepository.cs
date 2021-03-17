using System;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class BillingItemConfigurationRepository : BaseRepository<BillingItemConfiguration, Guid>, IBillingItemConfigurationRepository
    {
        public BillingItemConfigurationRepository(RevenueContext context):  base(context)
        {

        }
    }
}
