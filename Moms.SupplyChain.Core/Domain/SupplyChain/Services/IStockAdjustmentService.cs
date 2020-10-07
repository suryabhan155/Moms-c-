using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockAdjustmentService
    {
        Task<(bool IsSuccess, IEnumerable<StockAdjustment>, String ErrorMessage)> LoadStockAdjustment();
        (bool IsSuccess, StockAdjustment, String ErrorMessage) GetStockAdjustment(Guid id);
        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteStockAdjustment(Guid id);

        Task<(bool IsSuccess, StockAdjustment stockAdjustment, String ErrorMessage)> AddStockAdjustment(
            StockAdjustment stockAdjustment);

    }
}
