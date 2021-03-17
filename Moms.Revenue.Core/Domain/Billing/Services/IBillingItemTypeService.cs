using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingItemTypeService
    {
        Task<(bool IsSuccess, BillingItemType item, ResponseModel response)> CreateItem(BillingItemType itemMaster);
        Task<(bool IsSuccess, IEnumerable<BillingItemType> billingItems, ResponseModel response)> GetAllBillingItem();
        Task<(bool IsSuccess, BillingItemType billingItem, ResponseModel response)> GetBillingItemById(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel response)> Delete(Guid Id);
    }
}
