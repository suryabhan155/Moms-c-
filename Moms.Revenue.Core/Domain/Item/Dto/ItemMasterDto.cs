using System;

namespace Moms.RevenueManagement.Core.Domain.Item.Dto
{
    public class ItemMasterDto
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public string  DisplayName { get; set; }
        public Guid ItemTypeId { get; set; }
        public Guid ItemSubTypeId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Abbreviation { get; set; }
    }
}
