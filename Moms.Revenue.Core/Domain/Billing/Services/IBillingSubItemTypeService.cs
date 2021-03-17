using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingSubItemTypeService
    {
        Task<(bool IsSuccess, BillingSubItemType item, ResponseModel response)> CreateItem(BillingSubItemType itemMaster);
        Task<(bool IsSuccess, IEnumerable<BillingSubItemType> billingItems, ResponseModel response)> GetAllBillingItem();
        Task<(bool IsSuccess, BillingSubItemType billingItem, ResponseModel response)> GetBillingItemById(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel response)> Delete(Guid Id);
    }
}
