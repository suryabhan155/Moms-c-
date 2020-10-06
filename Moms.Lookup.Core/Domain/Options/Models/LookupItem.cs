using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class LookupItem: Entity<Guid>
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public LookupItem()
        {

        }
    }
}
