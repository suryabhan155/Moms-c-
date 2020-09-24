using System;
using System.Collections.Generic;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class LookupItem: Entity<Guid>
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public ICollection<LookupOption> lookupOptions { get; set; }=new List<LookupOption>();

        public LookupItem()
        {

        }

       /* public LookupItem(string name)
        {
            if(string.IsNullOrEmpty(name)) throw  new ArgumentNullException(nameof(name));
            Name = name;
        }


        public LookupItem()
        {

        }*/
    }
}
