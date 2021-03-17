using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingTypeService
    {
        Task<(bool IsSuccess, BillingType billingType , ResponseModel model)> Create(BillingType billingType);
        Task<(bool IsSuccess, IEnumerable<BillingType> billingTypes, ResponseModel model)> GetAllBillingType();
        Task<(bool IsSuccess, BillingType billingType , ResponseModel model)> GetBillType(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
