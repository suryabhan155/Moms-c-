using System;
using System.Collections.Generic;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Item.Models
{
    public class ItemMaster: Entity<Guid>
    {
        public string  Name { get; set; }
        public string  DisplayName { get; set; }
        public Guid? ItemTypeId { get; set; }
        public Guid ItemSubTypeId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Abbreviation { get; set; }
        public Guid Type { get; set; }
        public ItemTypeSubType ItemTypeSubType { get; set; }
        public ItemType ItemType  { get; set; }
        public ItemConfiguration ItemConfiguration { get; set; }
        public PriceList PriceList { get; set; }
        public ClientBillPayment ClientBillPayments { get; set; }
    }
}
