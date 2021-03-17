using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockAdjustmentItemService
    {
        Task<(bool IsSuccess, IEnumerable<StockAdjustmentItem>, ResponseModel response)> LoadStockAdjustmentItem();
        (bool IsSuccess, StockAdjustmentItem stockAdjustmentItem, ResponseModel response) GetStockAdjustmentItem(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockAdjustmentItem(Guid id);
        Task<(bool IsSuccess, StockAdjustmentItem stockAdjustmentItem, ResponseModel response)> AddStockAdjustmentItem(
            StockAdjustmentItem stockAdjustmentItem);
    }
}
