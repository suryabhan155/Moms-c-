using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPaymentTypeService
    {
        Task<(bool IsSuccess, PaymentType itemConfiguration , ResponseModel model)> Create(PaymentType paymentType);
        Task<(bool IsSuccess, IEnumerable<PaymentType> paymentType , ResponseModel model)> GetAllPaymentType();
        Task<(bool IsSuccess, PaymentType itemConfiguration , ResponseModel model)> GetPaymentType(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
