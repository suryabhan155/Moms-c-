using System;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Facilities.Models
{
    public class Clinic : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
