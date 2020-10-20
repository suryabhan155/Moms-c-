using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillingItemService
    {
        Task<(bool IsSuccess, ClientBillingItem clientBillingItem , string ErrorMessage)> Create(ClientBillingItem clientBillingItem);
        Task<(bool IsSuccess, IEnumerable<ClientBillingItem>  clientBillingItem, string ErrorMessage)> GetAllClientBillingItem();
        Task<(bool IsSuccess, IEnumerable<ClientBillingItem>  clientBillingItem , string ErrorMessage)> GetClientBillingItem(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
