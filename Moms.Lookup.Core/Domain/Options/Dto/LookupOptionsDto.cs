using System;

namespace Moms.Lookup.Core.Domain.Options.Dto
{
    public class LookupOptionsDto
    {
        public Guid Id { get; set; }
        public string LookupName { get; set; }
        public string LookupNameAlias { get; set; }
        public Guid LookupMasterId { get; set; }
        public string LookupMaster { get; set; }
        public string LookupMasterAlias { get; set; }
        public Guid LookupItemId { get; set; }
        public string LookupItem { get; set; }
        public string LookupItemAlias { get; set; }

    }
}
