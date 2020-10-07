using System;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class BillingDiscount:Entity<Guid>
    {
        public string Name { get; set; }
        public Boolean IsPercentage { get; set; }
        public Decimal MinDiscount { get; set; }
        public Decimal MaxDiscount { get; set; }
        public Boolean NeedsApproval { get; set; }
        public Boolean Status { get; set; }

        public BillingDiscount()
        {

        }

        public BillingDiscount(string name, decimal minDiscount, decimal maxDiscount)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(name);
            if(minDiscount<1) throw new ArgumentOutOfRangeException(nameof(minDiscount));
            if(MaxDiscount<1) throw new ArgumentOutOfRangeException(nameof(maxDiscount));
            Name = name;
            MinDiscount = minDiscount;
            MaxDiscount = maxDiscount;
        }
    }
}
