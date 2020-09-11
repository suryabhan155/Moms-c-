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

        public BillingDiscount(string name, Boolean isPercentage, decimal minDiscount, decimal maxDiscount, Boolean needsApproval)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(name);
            if(isPercentage==null) throw new ArgumentNullException(nameof(isPercentage));
            if(minDiscount<1) throw new ArgumentOutOfRangeException(nameof(minDiscount));
            if(MaxDiscount<1) throw new ArgumentOutOfRangeException(nameof(maxDiscount));
            if(needsApproval==null) throw new ArgumentNullException(nameof(needsApproval));

            Name = name;
            IsPercentage = isPercentage;
            MinDiscount = minDiscount;
            MaxDiscount = maxDiscount;
            NeedsApproval = needsApproval;
        }
    }
}
