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

       public IEnumerable<ItemMaster> Items = new List<ItemMaster>();
       public IEnumerable<Module> Modules= new List<Module>();
       public IEnumerable<BillingType> BillingTypes=new List<BillingType>();
       public ClientBillingItem ClientBillingItems { get; set; }


    }
}
