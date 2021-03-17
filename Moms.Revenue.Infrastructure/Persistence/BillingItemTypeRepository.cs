using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class BillingItemTypeRepository : BaseRepository<BillingItemType, Guid>, IBillingItemTypeRepository
    {
        public BillingItemTypeRepository(RevenueContext context) : base(context)
        {

        }
    }
}
