using System;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class BillingType: Entity<Guid>
    {
      public string  Name { get; set; }
      public Boolean  Status { get; set; }
      public PriceList PriceList { get; set; }

      public BillingType()
      {

      }
      public BillingType(string name)
      {
          if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

          Name = name;
      }
    }
}