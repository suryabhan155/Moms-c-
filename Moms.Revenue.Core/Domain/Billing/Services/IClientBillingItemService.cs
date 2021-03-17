using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillingItemService
    {
        Task<(bool IsSuccess, ClientBillingItem clientBillingItem , ResponseModel model)> Create(ClientBillingItem clientBillingItem);
        Task<(bool IsSuccess, IEnumerable<ClientBillingItem>  clientBillingItem, ResponseModel model)> GetAllClientBillingItem();
        Task<(bool IsSuccess, IEnumerable<ClientBillingItem>  clientBillingItem , ResponseModel model)> GetClientBillingItem(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
