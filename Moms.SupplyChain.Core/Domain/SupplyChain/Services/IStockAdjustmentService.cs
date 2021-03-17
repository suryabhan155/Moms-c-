using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockAdjustmentService
    {
        Task<(bool IsSuccess, IEnumerable<StockAdjustment>, ResponseModel response)> LoadStockAdjustment();
        (bool IsSuccess, StockAdjustment stockAdjustment, ResponseModel response) GetStockAdjustment(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockAdjustment(Guid id);

        Task<(bool IsSuccess, StockAdjustment stockAdjustment, ResponseModel response)> AddStockAdjustment(
            StockAdjustment stockAdjustment);

    }
}
