using System;
using System.Collections.Generic;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Item.Models
{
    public class ItemConfiguration: Entity<Guid>
    {
       public Guid ItemMasterId { get; set; }
       public int MaxStock { get; set; }
       public int MinStock { get; set; }
       public decimal PurchaseUnitPrice { get; set; }
       public decimal QuantityPerPurchaseUnit { get; set; }
       public string DispensingUnit { get; set; }
       public string PurchaseUnit { get; set; }
       public string QuantityPerDispenseUnit { get; set; }
       public bool Status { get; set; }
       public IEnumerable<ItemMaster> ItemMasters { get; set; }

       public ItemConfiguration(Guid itemMasterId, int maxStock, int minStock, decimal purchaseUnitPrice, decimal quantityPerPurchaseUnit,
           string dispensingUnit, string purchaseUnit, string quantityPerDispenseUnit)
       {
            if(itemMasterId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemMasterId));
            if(maxStock<1) throw new ArgumentOutOfRangeException(nameof(maxStock));
            if(minStock<1) throw new ArgumentOutOfRangeException(nameof(minStock));
            if(purchaseUnitPrice<1) throw  new ArgumentOutOfRangeException(nameof(purchaseUnitPrice));
            if(string.IsNullOrEmpty(dispensingUnit)) throw new ArgumentNullException(nameof(dispensingUnit));
            if(quantityPerPurchaseUnit<1) throw new ArgumentOutOfRangeException(nameof(quantityPerPurchaseUnit));
            if(string.IsNullOrEmpty(purchaseUnit)) throw new ArgumentNullException(nameof(purchaseUnit));
            if(string.IsNullOrEmpty(quantityPerDispenseUnit)) throw new ArgumentNullException(quantityPerDispenseUnit);

            MaxStock = maxStock;
            MinStock = minStock;
            QuantityPerDispenseUnit = quantityPerDispenseUnit;
            PurchaseUnitPrice = PurchaseUnitPrice;
            DispensingUnit = dispensingUnit;
            PurchaseUnit = purchaseUnit;
            QuantityPerPurchaseUnit = quantityPerPurchaseUnit;
       }
    }
}
