using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Item.Models
{
    public class ItemType:Entity<Guid>
    {
       public string Name { get; set; }
       public bool Status { get; set; }
       public IEnumerable<ItemTypeSubType>  ItemTypeSubType { get; set; }
       public IEnumerable<ItemMaster>  ItemMaster { get; set; }

       public ItemType()
       {

       }

    }
}
