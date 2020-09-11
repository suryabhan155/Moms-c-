using System;

namespace Moms.RevenueManagement.Core.Domain.Billing.Dto
{
    public class PriceListDto
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
