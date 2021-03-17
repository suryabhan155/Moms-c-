using System;
using System.Collections.Generic;
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
    public class ClientBillPaymentService:IClientBillPaymentService
    {
        private readonly IClientBilPaymentRepository _clientBilPaymentRepository;

        public ClientBillPaymentService(IClientBilPaymentRepository clientBilPaymentRepository)
        {
            _clientBilPaymentRepository = clientBilPaymentRepository;
        }
        public async Task<(bool IsSuccess, ClientBillPayment clientBillPayment, ResponseModel model)> Create(ClientBillPayment clientBillPayment)
        {
            try
            {
                if(clientBillPayment.Id.IsNullOrEmpty())
                    _clientBilPaymentRepository.Create(clientBillPayment);
                _clientBilPaymentRepository.Update(clientBillPayment);
               await  _clientBilPaymentRepository.Save();
                return (true, clientBillPayment, new ResponseModel { message = "Client bill payment Saved", data = clientBillPayment , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Bill Payment", e.Message);
                return(false, clientBillPayment, new ResponseModel { message = e.Message, data = clientBillPayment , code = HttpStatusCode.NotFound });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillPayment> clientBillPayment, ResponseModel model)> GetAllClientBillPayment()
        {
            try
            {
                var result = _clientBilPaymentRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Payments Bill Loaded", data = result , code = HttpStatusCode.OK }) : (false, new List<ClientBillPayment>(), new ResponseModel { message = "No Client Payment Found", data = new List<ClientBillPayment>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Client Bill Payment",e.Message);
                return(false,new List<ClientBillPayment>(), new ResponseModel { message = e.Message, data = new List<ClientBillPayment>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillPayment>  clientBillPayment, ResponseModel model)> GetClientBillPayment(Guid ClientBillingId)
        {
            try
            {
                var result = await _clientBilPaymentRepository.GetAll(x => x.ClientBillingId == ClientBillingId)
                    .Include(x => x.PaymentTypes)
                    .Include(p =>p.Modules)
                    .ToListAsync();
                if (result == null)
                    return (false, new List<ClientBillPayment>(), new ResponseModel { message = "Client Bill  Payment Not Found", data = result, code = HttpStatusCode.NotFound } );
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Patient Bill Payment Loaded", data = result , code = HttpStatusCode.OK }) : (false, new List<ClientBillPayment>(), new ResponseModel { message = "Client Bill  Payment Not Found", data = result, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Client Bill Payment(s)",e.Message);
                return(false,new List<ClientBillPayment>(), new ResponseModel { message = e.Message, data = new List<ClientBillPayment>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _clientBilPaymentRepository.GetAll(x => x.Id == Id && !x.Void).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Client Bill Payment not Found", data = Id , code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Client Bill Payment not Found", data = Id , code = HttpStatusCode.NotFound });
                result.VoidDate=DateTime.Today;
                result.Void = true;
                _clientBilPaymentRepository.Update(result);
                await _clientBilPaymentRepository.Save();
                return (true, Id, new ResponseModel { message = "Client Bill Payment Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Client Bill Payment(s)",e.Message);
                return(false,Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
