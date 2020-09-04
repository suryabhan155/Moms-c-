using System;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
{
    public class BillingDiscount:Entity<Guid>
    {
        public string Name { get; set; }
        public Boolean IsPercentage { get; set; }
        public Decimal MinDiscount { get; set; }
        public Decimal MaxDiscount { get; set; }
        public Boolean NeedsApproval { get; set; }
        public Boolean Status { get; set; }
    }
}
