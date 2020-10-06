using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockVoucherItemService
    {
        Task<(bool IsSuccess, IEnumerable<StockVoucherItem>, String ErrorMessage)> LoadStockVoucherItem();

        Task<(bool IsSuccess, IEnumerable<StockVoucherItem> stockVoucherItems, String ErrorMessage)>
            GetStockVoucherItem(Guid id);

        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteStockVoucherItem(Guid id);

        Task<(bool IsSuccess, StockVoucherItem stockVoucherItem, String ErrorMessage)> AddStockVoucherItem(
            StockVoucherItem stockVoucherItem);
    }
}
