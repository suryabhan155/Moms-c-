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
        public StockAdjustment()
        {

        }
    }
}
