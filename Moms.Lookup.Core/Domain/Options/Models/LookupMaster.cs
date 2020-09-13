using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class LookupMaster:Entity<Guid>
    {
        public string Name { get; set; }
        public string Alias { get; set; }


        public LookupMaster(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }
    }
}
