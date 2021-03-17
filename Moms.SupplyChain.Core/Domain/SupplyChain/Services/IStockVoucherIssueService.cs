using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IStockVoucherIssueService
    {
        Task<(bool IsSuccess, IEnumerable<StockVoucherIssue>, ResponseModel response)> LoadStockVoucherIssue();
        (bool IsSuccess, StockVoucherIssue stockVoucherIssues, ResponseModel response) GetStockVoucherIssue(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucherIssue(Guid id);

        Task<(bool IsSuccess, StockVoucherIssue stockVoucherIssue, ResponseModel response)> AddStockVoucherIssue(
            StockVoucherIssue stockVoucher);
    }
}
