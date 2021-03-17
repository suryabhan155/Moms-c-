using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeSubBlock : Entity<Guid>
    {
        public Guid IcdCodeBlockId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
    }
}
