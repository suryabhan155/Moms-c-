using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPriceListService
    {
        Task<(bool IsSuccess, PriceList priceList , string ErrorMessage)> Create(PriceList priceList);
        Task<(bool IsSuccess, IEnumerable<PriceList> priceList, string ErrorMessage)> GetAllPriceList();
        Task<(bool IsSuccess, PriceList priceList , string ErrorMessage)> GetPriceList(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
