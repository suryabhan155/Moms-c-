using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Billing.Dto;

namespace Moms.Revenue.Core.Domain.Billing
{
    public interface IBillingService
    {
        IEnumerable<PaymentTypeDto> LoadPaymentTypes();
    }
}
