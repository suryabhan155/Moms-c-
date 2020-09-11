using System;

namespace Moms.RevenueManagement.Core.Domain.Billing.Dto
{
    public class BillingDiscountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Boolean IsPercentage { get; set; }
        public Decimal MinDiscount { get; set; }
        public Decimal MaxDiscount { get; set; }
        public Boolean NeedsApproval { get; set; }
        public Boolean Status { get; set; }
    }
}
