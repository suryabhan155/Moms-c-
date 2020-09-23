using System;
using System.Collections.Generic;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class LookupOption:Entity<Guid>
    {
        public string LookupName { get; set; }
        public Guid LookupMasterId { get; set; }
        public Guid LookupItemId { get; set; }
        public string LookupNameAlias { get; set; }

        public LookupMaster lookupMater { get; set; }
        public LookupItem lookupItem { get; set; }

        public LookupOption(string lookupName, Guid lookupMasterId, Guid lookupItemId)
        {
            if(string.IsNullOrEmpty(lookupName)) throw new ArgumentNullException(nameof(lookupName));
            if(lookupMasterId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(lookupMasterId));
            if(lookupItemId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(lookupItemId));

            LookupName = lookupName;
            LookupMasterId = lookupMasterId;
            LookupItemId = lookupItemId;
        }
    }
}
