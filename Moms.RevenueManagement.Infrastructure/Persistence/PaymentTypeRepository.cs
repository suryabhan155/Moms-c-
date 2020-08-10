using System;
using Moms.RevenueManagement.Core.Domain.Billing;
using Moms.RevenueManagement.Core.Domain.Billing.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RevenueManagement.Infrastructure.Persistence
{
    public class PaymentTypeRepository : BaseRepository<PaymentType, Guid>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(RevenueContext context) : base(context)
        {
        }
    }
}
