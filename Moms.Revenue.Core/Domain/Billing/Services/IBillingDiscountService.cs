using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingDiscountService
    {
        Task<(bool IsSuccess, BillingDiscount billingDiscount , ResponseModel model)> Create(BillingDiscount billingDiscount);
        Task<(bool IsSuccess, IEnumerable<BillingDiscount> billingDiscounts, ResponseModel model)> GetAllBillingDiscounts();
        Task<(bool IsSuccess, BillingDiscount billingDiscount , ResponseModel model)> GetBillingDiscount(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
