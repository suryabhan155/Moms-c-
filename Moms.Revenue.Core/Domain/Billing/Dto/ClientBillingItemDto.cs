using System;

namespace Moms.Revenue.Core.Domain.Billing.Dto
{
    public class ClientBillingItemDto
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid ItemMasterId { get; set; }
        public Guid PriceListId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal  Price { get; set; }
        public Boolean Status { get; set; }
    }
}
