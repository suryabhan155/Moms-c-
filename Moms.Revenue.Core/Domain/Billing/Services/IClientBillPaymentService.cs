using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillPaymentService
    {
        Task<(bool IsSuccess, ClientBillPayment clientBillPayment , ResponseModel model)> Create(ClientBillPayment clientBillPayment);
        Task<(bool IsSuccess, IEnumerable<ClientBillPayment> clientBillPayment, ResponseModel model)> GetAllClientBillPayment();
        Task<(bool IsSuccess, IEnumerable<ClientBillPayment>  clientBillPayment , ResponseModel model)> GetClientBillPayment(Guid ClientBillingID);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
