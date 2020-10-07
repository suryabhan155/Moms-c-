using System;

namespace Moms.RevenueManagement.Core.Domain.Item.Dto
{
    public class ItemConfigurationDto
    {
        public Guid Id { get; set; }
        public Guid ItemMasterId { get; set; }
        public int MaxStock { get; set; }
        public int MinStock { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal QuantityPerPurchaseUnit { get; set; }
        public string DispensingUnit { get; set; }
        public string PurchaseUnit { get; set; }
        public string QuantityPerDispenseUnit { get; set; }
        public bool Status { get; set; }
    }
}
