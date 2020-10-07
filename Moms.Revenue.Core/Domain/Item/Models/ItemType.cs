using System;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Item.Models
{
    public class ItemType:Entity<Guid>
    {
       public string Name { get; set; }
       public bool Status { get; set; }
       public ItemTypeSubType ItemTypeSubType { get; set; }
       public ItemMaster ItemMaster { get; set; }

       public ItemType(string name)
       {
           if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(Name));

           Name = name;
       }
    }
}
