using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Dto;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillingService
    {
       /* IEnumerable<PaymentTypeDto> LoadPaymentTypes();*/
        Task<(bool IsSuccess, ClientBill clientBill , string ErrorMessage)> Create(ClientBill clientBill);
        Task<(bool IsSuccess, IEnumerable<ClientBill> clientBills, string ErrorMessage)> GetAllBilling();
        Task<(bool IsSuccess, IEnumerable<ClientBill>  clientBill , string ErrorMessage)> GetClientBill(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
