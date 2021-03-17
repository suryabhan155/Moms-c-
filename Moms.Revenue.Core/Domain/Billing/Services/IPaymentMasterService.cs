using Moms.Revenue.Core.Domain.Billing.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPaymentMasterService
    {
        Task<(bool IsSuccess, PaymentMaster payment, ResponseModel model)> CreatePayment(PaymentMaster payment);
        Task<(bool IsSuccess, IEnumerable<PaymentMaster> payment, ResponseModel model)> GetAllPaymentMethod();
        Task<(bool IsSuccess, PaymentMaster payment, ResponseModel model)> GetPaymentMethod(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
