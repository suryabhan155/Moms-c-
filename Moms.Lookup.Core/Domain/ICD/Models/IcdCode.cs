using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCode : Entity<Guid>
    {
        public Guid IcdCodeSubBlockId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }

        //public IcdCodeSubBlock IcdCodeSubBlock { get; set; }
    }
}
