using System;
using System.Collections.Generic;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Item.Models
{
    public class ItemTypeSubType: Entity<Guid>
    {
        public Guid ItemTypeId { get; set; }
        public string Name { get; set; }
        public Boolean Status { get; set; }
        public ItemType  ItemType { get; set; }
        public IEnumerable<ItemMaster>  ItemMaster { get; set; }

        public ItemTypeSubType()
        {

        }
        public ItemTypeSubType(Guid itemTypeId, string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if(itemTypeId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemTypeId));

            ItemTypeId = itemTypeId;
            Name = name;
        }
    }
}
