using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class StockAdjustmentItem : Entity<Guid>
    {
        public Guid StoreAdjustmentId { set; get; }
        public Guid ItemId { set; get; }
        public String BatchNumber { set; get; }
        public Guid AdjustmentReasonId { set; get; }
        public decimal Quantity { set; get; }

        public StockAdjustmentItem()
        {

        }
    }
}
