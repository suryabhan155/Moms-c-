using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCode : Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Guid IcdCodeSubBlockId { get; set; }

        public IcdCodeSubBlock IcdCodeSubBlock { get; set; }
    }
}
