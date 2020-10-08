using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class PurchaseOrderItem : Entity<Guid>
    {
        public Guid PurchaseOrderId { set; get; }
        public Guid ItemId { set; get; }
        public decimal OrderedQuantity { set; get; }
        public int Status { set; get; }

        public PurchaseOrderItem()
        {

        }

    }
}
