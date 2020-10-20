using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class ClientBillPaymentService:IClientBillPaymentService
    {
        private readonly IClientBilPaymentRepository _clientBilPaymentRepository;

        public ClientBillPaymentService(IClientBilPaymentRepository clientBilPaymentRepository)
        {
            _clientBilPaymentRepository = clientBilPaymentRepository;
        }
        public async Task<(bool IsSuccess, ClientBillPayment clientBillPayment, string ErrorMessage)> Create(ClientBillPayment clientBillPayment)
        {
            try
            {
                if(clientBillPayment.Id.IsNullOrEmpty())
                    _clientBilPaymentRepository.Create(clientBillPayment);
                _clientBilPaymentRepository.Update(clientBillPayment);
               await  _clientBilPaymentRepository.Save();
                return (true, clientBillPayment, "Client bill payment Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Bill Payment", e.Message);
                return(false, clientBillPayment, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillPayment> clientBillPayment, string ErrorMessage)> GetAllClientBillPayment()
        {
            try
            {
                var result = await _clientBilPaymentRepository.GetAll().ToListAsync();
                return result.Count > 0 ? (true, result, "Payments Bill Loaded") : (false, new List<ClientBillPayment>(), "No Client Payment Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Client Bill Payment",e.Message);
                return(false,new List<ClientBillPayment>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillPayment>  clientBillPayment, string ErrorMessage)> GetClientBillPayment(Guid ClientBillingId)
        {
            try
            {
                var result = await _clientBilPaymentRepository.GetAll(x => x.ClientBillingId == ClientBillingId)
                    .Include(x => x.PaymentTypes)
                    .Include(x=>x.Modules)
                    .ToListAsync();
                return result.Count > 0 ? (true, result, "Patient Bill Payment Loaded") : (false, new List<ClientBillPayment>(), "Client Bill  Payment Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Client Bill Payment(s)",e.Message);
                return(false,new List<ClientBillPayment>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _clientBilPaymentRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Client Bill Payment not Found");
                result.VoidDate=DateTime.Today;
                result.Void = true;
                await _clientBilPaymentRepository.Save();
                return (true, Id, "Client Bill Payment Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Client Bill Payment(s)",e.Message);
                return(false,Id, e.Message);
            }
        }
    }
}
