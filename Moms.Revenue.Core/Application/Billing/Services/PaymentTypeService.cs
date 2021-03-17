using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;
using Moms.SharedKernel.Response;
using System.Net;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        public async Task<(bool IsSuccess, PaymentType itemConfiguration, ResponseModel model)> Create(PaymentType payment)
        {
            try
            {
                if (payment.Id.IsNullOrEmpty())
                    _paymentTypeRepository.Create(payment);
                else
                    _paymentTypeRepository.Update(payment);
                await _paymentTypeRepository.Save();
                return (true, payment, new ResponseModel { message = "Payment Method Saved", data = payment, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Payment Method", e.Message);
                return (false, payment, new ResponseModel { message = e.Message, data = payment, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _paymentTypeRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Payment Method Does Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    if (result.Id.IsNullOrEmpty())
                        return (false, Id, new ResponseModel { message = "Error Deleting Payment Type", data = Id, code = HttpStatusCode.NotFound });
                    else
                    {
                        result.Void = true;
                        result.VoidDate = DateTime.Today;
                        _paymentTypeRepository.Update(result);
                        await _paymentTypeRepository.Save();
                        return (true, Id, new ResponseModel { message = "Payment Method deleted", data = Id, code = HttpStatusCode.OK });
                    }
                }
            }
            catch (Exception e)
            {
               Log.Error("Error Deleting Payment Method");
               return (false, Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PaymentType> paymentType, ResponseModel model)> GetAllPaymentType()
        {
            try
            {
                var result = await _paymentTypeRepository.GetAll(x => x.Void == false).ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Payment Loaded", data = result, code = HttpStatusCode.OK }) : (false, new List<PaymentType>(), new ResponseModel { message = "Payment Method Not Found", data = new List<PaymentType>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error loading Payment Method", e.Message);
                return (false, new List<PaymentType>(), new ResponseModel { message = e.Message, data = new List<PaymentType>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, PaymentType itemConfiguration, ResponseModel model)> GetPaymentType(Guid Id)
        {
            try
            {
                var result = await _paymentTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                    return (false, new PaymentType(), new ResponseModel { message = "Payment Method Not Found", data = result, code = HttpStatusCode.NotFound });
                else
                    return result.Id.IsNullOrEmpty() ? (false, new PaymentType(), new ResponseModel { message = "Payment Method Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Payment Method Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Payment Method", e.Message);
                return (false, new PaymentType(), new ResponseModel { message = e.Message, data = new PaymentType(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
