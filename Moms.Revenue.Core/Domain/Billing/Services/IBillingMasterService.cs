using Moms.Revenue.Core.Domain.Billing.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingMasterService
    {
        Task<(bool IsSuccess, BillingMaster billingmaster, ResponseModel model)> Create(BillingMaster billingType);
        Task<(bool IsSuccess, IEnumerable<BillingMaster> billingmaster, ResponseModel model)> GetAllBillingType();
        Task<(bool IsSuccess, BillingMaster billingmaster, ResponseModel model)> GetBillType(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
