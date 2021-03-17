using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockVoucherService
    {
        Task<(bool IsSuccess, IEnumerable<StockVoucher>, ResponseModel response)> LoadStockVoucher();
        (bool IsSuccess, StockVoucher stockVouchers, ResponseModel response) GetStockVoucher(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucher(Guid id);

        Task<(bool IsSuccess, StockVoucher stockVoucher, ResponseModel response)> AddStockVoucher(
            StockVoucher stockVoucher);
    }
}
