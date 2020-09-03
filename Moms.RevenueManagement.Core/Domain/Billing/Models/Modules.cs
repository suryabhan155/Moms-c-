using System;
using System.ComponentModel.DataAnnotations;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
{
    public class Modules: Entity<Guid>
    {
       [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
