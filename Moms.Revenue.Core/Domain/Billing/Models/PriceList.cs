using System;
using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class PriceList: Entity<Guid>
    {
       public Guid  ItemMasterId { get; set; }
       public string ItemName { get; set; }
       public Guid  ModuleId { get; set; }
       public Guid  BillTypeId { get; set; }
       public Decimal SellingPrice { get; set; }
       public DateTime EffectiveDate { get; set; }
       public Boolean IsDiscounted { get; set; }
       public Boolean Status { get; set; }

        public ItemMaster ItemMaster { get; set; }
        public Module Module { get; set; }
        public BillingType BillingType { get; set; }
        public ClientBillingItem ClientBillingItems { get; set; }


    }
}
