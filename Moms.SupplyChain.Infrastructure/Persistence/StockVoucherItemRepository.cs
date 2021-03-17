using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Infrastructure.Persistence
{
    public class StockVoucherItemRepository:BaseRepository<StockVoucherItem, Guid>, IStockVoucherItemRepository
    {
       public StockVoucherItemRepository(SupplyChainContext context) : base(context)
        {

        }
    }
}
