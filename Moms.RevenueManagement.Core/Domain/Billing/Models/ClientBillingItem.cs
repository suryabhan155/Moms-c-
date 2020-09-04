using System;
using System.Collections.Generic;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
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
    }
}
