using System;
using System.ComponentModel.DataAnnotations.Schema;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    [Table("LookupOptions")]
    public class LookupOption:Entity<Guid>
    {
       [Column("lookupmasterid")]
        public Guid LookupMasterId { get; set; }
       [Column("lookupmastername")]
        public string LookupMasterName { get; set; }
       [Column("lookupmasteralias")]
        public string LookupMasterAlias { get; set; }
       [Column("lookupitemid")]
       public Guid  LookupItemId { get; set; }
       [Column("lookupitemname")]
       public string LookupItemName { get; set; }
       [Column("lookupitemalias")]
       public string LookupItemAlias { get; set; }


    }
}
