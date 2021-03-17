using System;

namespace Moms.RevenueManagement.Core.Domain.Item.Dto
{
    public class ItemTypeSubTypeDto
    {
        public Guid Id { get; set; }
        public Guid ItemTypeId { get; set; }
        public string Name { get; set; }
        public Boolean Status { get; set; }
    }
}
