using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class BillingSubItemType : Entity<Guid>
    {
        public BillingSubItemType()
        {

        }
        public BillingSubItemType(string name,Guid itemtypeid)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (itemtypeid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemtypeid));

            Name = name;
            ItemTypeID = itemtypeid;
        }
        public string Name { get; set; }
        public Guid ItemTypeID { get; set; }
        public Boolean Status { get; set; }

        //public IEnumerable<BillingItemType> BillingItemTypes { get; set; }
    }
}
