using System;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
{
    public class ItemType:Entity<Guid>
    {
       public string Name { get; set; }
       public bool Status { get; set; }
    }
}
