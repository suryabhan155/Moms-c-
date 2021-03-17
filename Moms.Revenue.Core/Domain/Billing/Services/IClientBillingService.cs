using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Dto;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IClientBillingService
    {
       /* IEnumerable<PaymentTypeDto> LoadPaymentTypes();*/
        Task<(bool IsSuccess, ClientBill clientBill , ResponseModel model)> Create(ClientBill clientBill);
        Task<(bool IsSuccess, IEnumerable<ClientBill> clientBills, ResponseModel model)> GetAllBilling();
        Task<(bool IsSuccess, IEnumerable<ClientBill>  clientBill , ResponseModel model)> GetClientBill(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
