using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPriceMasterService
    {
        Task<(bool IsSuccess, PriceMaster price , ResponseModel model)> Create(PriceMaster price);
        Task<(bool IsSuccess, IEnumerable<PriceMaster> price, ResponseModel model)> GetAllPriceMaster();
        Task<(bool IsSuccess, PriceMaster price , ResponseModel model)> GetPriceMaster(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
