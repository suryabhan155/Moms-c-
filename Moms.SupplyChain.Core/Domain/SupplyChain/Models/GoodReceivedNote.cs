using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class GoodReceivedNote : Entity<Guid>
    {
        public Guid PurchaseOrderId { set; get; }
        public DateTime ReceivedDateTime { set; get; }

        public PurchaseOrder PurchaseOrder { set; get; }

    }
}
