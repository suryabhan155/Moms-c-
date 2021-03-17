using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class BillingItemMaster : Entity<Guid>
    {
        public BillingItemMaster()
        {

        }
        public BillingItemMaster(string name,Guid itemtypeid,Guid itemsubtypeid)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (itemtypeid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemtypeid));
            if (itemsubtypeid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemsubtypeid));
            Name = name;
            ItemTypeId = itemtypeid;
            ItemSubTypeId = itemsubtypeid;
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Guid? ItemTypeId { get; set; }
        public Guid ItemSubTypeId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Abbreviation { get; set; }
        public string Type { get; set; }
        //public BillingSubItemType ItemTypeSubType { get; set; }
        //public BillingItemType ItemType { get; set; }
    }
}
