using System;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.Options.Models
{
    public class CountyLookup:Entity<Guid>
    {
       public Guid CountyUid { get; set; }
       public int CountyCode { get; set; }
       public string CountyName { get; set; }
       public Guid SubCountyUid { get; set; }
       public int SubCountyCode { get; set; }
       public string  SubCountyName { get; set; }
       public Guid WardUid { get; set; }
       public int WardCode { get; set; }
       public string WardName { get; set; }

    }
}
