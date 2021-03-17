using System;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Revenue.Infrastructure.Persistence
{
    public class PaymentTypeRepository : BaseRepository<PaymentType, Guid>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(RevenueContext context) : base(context)
        {
        }
    }
}
