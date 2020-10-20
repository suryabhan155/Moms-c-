using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IPaymentTypeService
    {
        Task<(bool IsSuccess, PaymentType itemConfiguration , string ErrorMessage)> Create(PaymentType paymentType);
        Task<(bool IsSuccess, IEnumerable<PaymentType> paymentType , string ErrorMessage)> GetAllPaymentType();
        Task<(bool IsSuccess, PaymentType itemConfiguration , string ErrorMessage)> GetPaymentType(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
