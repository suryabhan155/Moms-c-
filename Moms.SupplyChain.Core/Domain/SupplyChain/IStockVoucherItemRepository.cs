using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Interfaces.Persistence;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain
{
    public interface IStockVoucherItemRepository:IRepository<StockVoucherItem, Guid>
    {
    }
}
