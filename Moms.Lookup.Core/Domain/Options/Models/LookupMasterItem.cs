using System;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class LookupMasterItem:Entity<Guid>
    {
        public Guid LookupMasterId { get; set; }
        public Guid LookupItemId { get; set; }

        public LookupMasterItem()
        {

        }
    }


}
