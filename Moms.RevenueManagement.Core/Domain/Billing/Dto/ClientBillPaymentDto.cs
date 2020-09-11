using System;

namespace Moms.RevenueManagement.Core.Domain.Billing.Dto
{
    public class ClientBillPaymentDto
    {
        public Guid ClientBillingId { get; set; }
        public Guid ItemMasterId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid ModuleId { get; set; }
        public Decimal DiscountedAmount { get; set; }
        public Decimal Amount { get; set; }
        public Boolean Status { get; set; }
    }
}
