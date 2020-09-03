using System;
using System.ComponentModel.DataAnnotations.Schema;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
{
    public class ItemTypeSubType: Entity<Guid>
    {
        public Guid ItemTypeId { get; set; }
        public Guid Name { get; set; }
        public Boolean Status { get; set; }
        public ItemType ItemType { get; set; }
    }
}
