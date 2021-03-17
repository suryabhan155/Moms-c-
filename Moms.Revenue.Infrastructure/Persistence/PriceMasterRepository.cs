using System;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class PriceMasterRepository : BaseRepository<PriceMaster, Guid>, IPriceMasterRepository
    {
        public PriceMasterRepository(RevenueContext context) : base(context)
        {
        }
    }
}
