using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class BillingItemMasterRepository : BaseRepository<BillingItemMaster, Guid>, IBillingItemMasterRepository
    {
        public BillingItemMasterRepository(RevenueContext context) : base(context)
        {

        }
    }
}
