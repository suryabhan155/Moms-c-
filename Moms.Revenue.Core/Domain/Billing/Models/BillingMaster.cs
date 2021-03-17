using Moms.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class BillingMaster : Entity<Guid>
    { //it is billingtype 
        public BillingMaster()
        {

        }
        public BillingMaster(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        public string Name { get; set; }
        public Boolean Status { get; set; }
    }
}
