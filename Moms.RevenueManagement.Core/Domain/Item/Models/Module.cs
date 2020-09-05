using System;
using System.ComponentModel.DataAnnotations;
using Moms.RevenueManagement.Core.Domain.Billing.Models;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Item.Models
{
    public class Module: Entity<Guid>
    {
       [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
        public PriceList PriceList { get; set; }
        public ClientBillPayment ClientBillPayment { get; set; }
    }
}
