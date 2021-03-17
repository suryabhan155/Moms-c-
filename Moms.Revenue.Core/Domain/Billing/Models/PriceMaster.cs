using System;
using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class PriceMaster : Entity<Guid>
    {
       public Guid  ItemMasterId { get; set; }
       public string ItemName { get; set; }
       public Guid  ModuleId { get; set; }
       public Guid  BillTypeId { get; set; }
       public Decimal SellingPrice { get; set; }
       public DateTime EffectiveDate { get; set; }
       public Boolean IsDiscounted { get; set; }
       public Boolean Status { get; set; }
    }
}
