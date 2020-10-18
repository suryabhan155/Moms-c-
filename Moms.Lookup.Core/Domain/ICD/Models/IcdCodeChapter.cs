using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeChapter : Entity<Guid>
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
