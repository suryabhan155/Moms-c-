using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillPaymentService
    {
        Task<(bool IsSuccess, ClientBillPayment clientBillPayment , string ErrorMessage)> Create(ClientBillPayment clientBillPayment);
        Task<(bool IsSuccess, IEnumerable<ClientBillPayment> clientBillPayment, string ErrorMessage)> GetAllClientBillPayment();
        Task<(bool IsSuccess, IEnumerable<ClientBillPayment>  clientBillPayment , string ErrorMessage)> GetClientBillPayment(Guid ClientBillingID);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
