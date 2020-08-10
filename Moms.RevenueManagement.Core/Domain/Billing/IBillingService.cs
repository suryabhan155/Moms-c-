using System.Collections.Generic;
using Moms.RevenueManagement.Core.Domain.Billing.Dto;

namespace Moms.RevenueManagement.Core.Domain.Billing
{
    public interface IBillingService
    {
        IEnumerable<PaymentTypeDto> LoadPaymentTypes();
    }
}
