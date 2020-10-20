using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingDiscountService
    {
        Task<(bool IsSuccess, BillingDiscount billingDiscount , string ErrorMessage)> Create(BillingDiscount billingDiscount);
        Task<(bool IsSuccess, IEnumerable<BillingDiscount> billingDiscounts, string ErrorMessage)> GetAllBillingDiscounts();
        Task<(bool IsSuccess, BillingDiscount billingDiscount , string ErrorMessage)> GetBillingDiscount(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
