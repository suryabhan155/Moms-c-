using System;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class PaymentType : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ClientBillPayment ClientBillPayment { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
