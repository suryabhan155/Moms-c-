using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class ClientBillingService:IClientBillingService
    {
        private readonly IClientBillRepository _clientBillRepository;
        private readonly IClientBillingItemRepository _clientBillingItemRepository;

        public ClientBillingService(IClientBillRepository clientBillRepository, IClientBillingItemRepository clientBillingItemRepository)
        {
            _clientBillRepository = clientBillRepository;
            _clientBillingItemRepository = clientBillingItemRepository;
        }

        public async Task<(bool IsSuccess, ClientBill clientBill, string ErrorMessage)> Create(ClientBill clientBill)
        {
            try
            {
                if(clientBill.Id.IsNullOrEmpty())
                    _clientBillRepository.Create(clientBill);
                _clientBillRepository.Update(clientBill);
                await _clientBillRepository.Save();
                return (true, clientBill, "Client Bill Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, clientBill, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBill> clientBills, string ErrorMessage)> GetAllBilling()
        {
            try
            {
                var result = await _clientBillRepository.GetAll(x => !x.Void).ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Client Bills Loaded");
                return (false, new List<ClientBill>(), "Client Bills Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, new List<ClientBill>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBill>  clientBill, string ErrorMessage)> GetClientBill(Guid Id)
        {
            try
            {
                var result = await _clientBillRepository.GetAll(x => x.PatientId == Id).ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Client Bills Loaded");
                return (false, new List<ClientBill>(), "Client Bill Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, new List<ClientBill>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
               /* check if bill has child items*/

               var item = _clientBillingItemRepository.GetAll(x => x.BillId == Id).ToList();
               if (item.Count > 0)
                   return (true, Id, "CANNOT Delete Bill With Existing Items");
               var result = await _clientBillRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "No Client Bill Item Found");
                result.VoidDate=DateTime.Today;
                result.Void = true;
                await _clientBillRepository.Save();
                return (true, Id, "Client Bill Item Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error in Deleting Client Bill",e);
                return (false, Id, e.Message);
            }
        }
    }
}
