using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;


namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeSubBlock : Entity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Guid IcdCodeBlockId { get; set; }
       
        public IcdCodeBlock IcdCodeBlock { get; set; }
        public ICollection<IcdCode> IcdCodes { get; set; } = new List<IcdCode>();
    }
}
