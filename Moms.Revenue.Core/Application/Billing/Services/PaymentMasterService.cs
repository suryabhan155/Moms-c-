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
using Moms.SharedKernel.Interfaces.Persistence;
using System.Linq;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class PaymentMasterService : IPaymentMasterService
    {
        private readonly IPaymentMasterRepository _paymentmasterRepository;

        public PaymentMasterService(IPaymentMasterRepository paymentmasterRepository)
        {
            _paymentmasterRepository = paymentmasterRepository;
        }

        public async Task<(bool IsSuccess, PaymentMaster payment, ResponseModel model)> CreatePayment(PaymentMaster payment)
        {
            try
            {
                if (payment.Id.IsNullOrEmpty())
                    _paymentmasterRepository.Create(payment);
                else
                    _paymentmasterRepository.Update(payment);
                await _paymentmasterRepository.Save();
                return (true, payment, new ResponseModel { message = "Payment Method Saved", data = payment , code = HttpStatusCode.NotFound } );
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Payment Method", e.Message);
                return (false, payment, new ResponseModel { message = e.Message, data = payment , code = HttpStatusCode.InternalServerError } );
            }
        }
        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _paymentmasterRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
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
                        _paymentmasterRepository.Update(result);
                        await _paymentmasterRepository.Save();
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

        public async Task<(bool IsSuccess, IEnumerable<PaymentMaster> payment, ResponseModel model)> GetAllPaymentMethod()
        {
            try
            {
                var result =_paymentmasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Payment Loaded", data = result , code = HttpStatusCode.OK }) : (false, new List<PaymentMaster>(), new ResponseModel { message = "Payment Method Not Found", data = new List<PaymentMaster>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error loading Payment Method", e.Message);
                return (false, new List<PaymentMaster>(), new ResponseModel { message = e.Message, data = new List<PaymentMaster>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, PaymentMaster payment, ResponseModel model)> GetPaymentMethod(Guid Id)
        {
            try
            {
                var result = await _paymentmasterRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                    return (false, new PaymentMaster(), new ResponseModel { message = "Payment Method Not Found", data = result, code = HttpStatusCode.NotFound });
                else
                    return result.Id.IsNullOrEmpty() ? (false, new PaymentMaster(), new ResponseModel { message = "Payment Method Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Payment Method Loaded", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Payment Method", e.Message);
                return (false, new PaymentMaster(), new ResponseModel { message = e.Message, data = new PaymentMaster(), code = HttpStatusCode.InternalServerError } );
            }
        }
    }
}
