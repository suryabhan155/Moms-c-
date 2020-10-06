using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockVoucherService
    {
        Task<(bool IsSuccess, IEnumerable<StockVoucher>, String ErrorMessage)> LoadStockVoucher();
        Task<(bool IsSuccess, IEnumerable<StockVoucher> stockVouchers, String ErrorMessage)> GetStockVoucher(Guid id);
        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteStockVoucher(Guid id);

        Task<(bool IsSuccess, StockVoucher stockVoucher, String ErrorMessage)> AddStockVoucher(
            StockVoucher stockVoucher);
    }
}
