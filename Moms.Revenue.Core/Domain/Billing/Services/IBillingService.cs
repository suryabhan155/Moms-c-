using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Billing.Dto;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingService
    {
        IEnumerable<PaymentTypeDto> LoadPaymentTypes();
    }
}
