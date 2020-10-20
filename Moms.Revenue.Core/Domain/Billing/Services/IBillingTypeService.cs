using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingTypeService
    {
        Task<(bool IsSuccess, BillingType billingType , string ErrorMessage)> Create(BillingType billingType);
        Task<(bool IsSuccess, IEnumerable<BillingType> billingTypes, string ErrorMessage)> GetAllBillingType();
        Task<(bool IsSuccess, BillingType billingType , string ErrorMessage)> GetBillType(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
