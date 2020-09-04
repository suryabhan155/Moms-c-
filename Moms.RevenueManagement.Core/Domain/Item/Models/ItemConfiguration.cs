using System;
using System.Collections.Generic;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Item
{
    public class ItemConfiguration: Entity<Guid>
    {
       public Guid ItemMasterId { get; set; }
       public int MaxStock { get; set; }
       public int MinStock { get; set; }
       public double PurchaseUnitPrice { get; set; }
       public double QuantityPerPurchaseUnit { get; set; }
       public string DispensingUnit { get; set; }
       public string PurchaseUnit { get; set; }
       public string QuantityPerDispenseUnit { get; set; }
       public bool Status { get; set; }
       public IEnumerable<ItemMaster> ItemMasters { get; set; }
    }
}
