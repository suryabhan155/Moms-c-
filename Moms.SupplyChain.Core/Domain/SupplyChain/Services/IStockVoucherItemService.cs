using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockVoucherItemService
    {
        Task<(bool IsSuccess, IEnumerable<StockVoucherItem>, ResponseModel response)> LoadStockVoucherItem();

        (bool IsSuccess, StockVoucherItem stockVoucherItems, ResponseModel response)
            GetStockVoucherItem(Guid id);

        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucherItem(Guid id);

        Task<(bool IsSuccess, StockVoucherItem stockVoucherItem, ResponseModel response)> AddStockVoucherItem(
            StockVoucherItem stockVoucherItem);
    }
}
