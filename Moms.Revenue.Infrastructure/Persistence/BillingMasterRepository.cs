using System;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class BillingMasterRepository : BaseRepository<BillingMaster, Guid>, IBillingMasterRepository
    {
        public BillingMasterRepository(RevenueContext context) : base(context)
        {
        }
    }
}
