using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Infrastructure.Persistence
{
    public class StockAdjustmentItemRepository : BaseRepository<StockAdjustmentItem, Guid>, IStockAdjustmentItemRepository
    {
      public StockAdjustmentItemRepository(SupplyChainContext context) : base(context)
        {

        }
    }
}
