using System;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class PriceListRepository:BaseRepository<PriceList, Guid>, IPriceListRepository
    {
        public PriceListRepository(RevenueContext context) : base(context)
        {
        }
    }
}
