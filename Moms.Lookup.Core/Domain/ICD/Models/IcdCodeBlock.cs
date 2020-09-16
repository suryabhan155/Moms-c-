using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeBlock : Entity<Guid>
    {
        public Guid ChapterId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }

        public IcdCodeChapter IcdCodeChapter { get; set; }
        public ICollection<IcdCodeSubBlock> Guardians { get; set; } = new List<IcdCodeSubBlock>();
    }
}
