using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class StockAdjustment:Entity<Guid>
    {
        public Guid StoreId { set; get; }
        public DateTime AdjustmentDateTime { set; get; }

        public Guid ItemId { set; get; }
        public String BatchNumber { set; get; }
        public Guid AdjustmentReasonId { set; get; }
        public decimal Quantity { set; get; }

        public Store Store { get; set; }
        
    }
}
