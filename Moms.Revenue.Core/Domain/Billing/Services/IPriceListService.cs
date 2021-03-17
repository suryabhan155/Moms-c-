using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPriceListService
    {
        Task<(bool IsSuccess, PriceList priceList , ResponseModel model)> Create(PriceList priceList);
        Task<(bool IsSuccess, IEnumerable<PriceList> priceList, ResponseModel model)> GetAllPriceList();
        Task<(bool IsSuccess, PriceList priceList , ResponseModel model)> GetPriceList(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
