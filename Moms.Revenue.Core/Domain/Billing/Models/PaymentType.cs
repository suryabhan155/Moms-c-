using System;
using System.Collections.Generic;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class PaymentType : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ClientBillPayment> ClientBillPayments  { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
