using System;
using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class ClientBillingItem:  Entity<Guid>
    {
        public Guid BillId { get; set; }
        public Guid ItemMasterId { get; set; }
        public Guid PriceListId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal  Price { get; set; }
        public Boolean Status { get; set; }

        public IEnumerable<ItemMaster> ItemMasters { get; set; }
        public IEnumerable<PriceList> PriceLists { get; set; }

        public ClientBillingItem()
        {

        }
        public ClientBillingItem(Guid billId, Guid itemMasterId, Guid priceListId, decimal quantity, decimal price)
        {
            if(billId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(billId));
            if(itemMasterId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemMasterId));
            if(priceListId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(priceListId));
            if(quantity<1) throw  new ArgumentOutOfRangeException(nameof(quantity));
            if(price<1) throw new ArgumentOutOfRangeException(nameof(price));

            BillId = billId;
            ItemMasterId = itemMasterId;
            PriceListId = priceListId;
            Quantity = quantity;
            Price = price;

        }
    }
}
