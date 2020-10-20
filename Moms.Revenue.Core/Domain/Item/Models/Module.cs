using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Item.Models
{
    public class Module: Entity<Guid>
    {
       [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
        public PriceList PriceList { get; set; }
        public IEnumerable<ClientBillPayment> ClientBillPayments  { get; set; }
    }
}
