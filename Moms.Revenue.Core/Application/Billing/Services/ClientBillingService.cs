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
using Moms.SharedKernel.Response;
using System.Net;

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

        public async Task<(bool IsSuccess, ClientBill clientBill, ResponseModel model)> Create(ClientBill clientBill)
        {
            try
            {
                if (clientBill.Id.IsNullOrEmpty())
                    _clientBillRepository.Create(clientBill);
                else
                {
                    _clientBillRepository.Update(clientBill);
                }
                await _clientBillRepository.Save();
                return (true, clientBill, new ResponseModel { message = "Client Bill Saved", data = clientBill , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, clientBill, new ResponseModel { message = e.Message, data = clientBill , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBill> clientBills, ResponseModel model)> GetAllBilling()
        {
            try
            {
                var result = await _clientBillRepository.GetAll(x => !x.Void).ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Client Bills Loaded", data = result , code = HttpStatusCode.OK });
                return (false, new List<ClientBill>(), new ResponseModel { message = "Client Bills Not Found", data = new List<ClientBill>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, new List<ClientBill>(), new ResponseModel { message = e.Message, data = new List<ClientBill>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBill>  clientBill, ResponseModel model)> GetClientBill(Guid Id)
        {
            try
            {
                //var result = await _clientBillRepository.GetAll(x => x.PatientId == Id).ToListAsync();
                var result = await _clientBillRepository.GetAll(x => x.Id == Id).ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Client Bills Loaded", data = result , code = HttpStatusCode.OK });
                return (false, new List<ClientBill>(), new ResponseModel { message = "Client Bill Not Found", data = result, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill",e);
                return (false, new List<ClientBill>(), new ResponseModel { message = e.Message, data = new List<ClientBill>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
               /* check if bill has child items*/

               var item = _clientBillingItemRepository.GetAll(x => x.BillId == Id).ToList();
               if (item.Count > 0)
                   return (true, Id, new ResponseModel { message = "CANNOT Delete Bill With Existing Items", data = Id , code = HttpStatusCode.NotFound });
               var result = await _clientBillRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if (result== null)
                    return (false, Id, new ResponseModel { message = "No Client Bill Item Found", data = Id, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "No Client Bill Item Found", data = Id , code = HttpStatusCode.NotFound });
                result.VoidDate=DateTime.Today;
                result.Void = true;
                await _clientBillRepository.Save();
                return (true, Id, new ResponseModel { message = "Client Bill Item Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Deleting Client Bill",e);
                return (false, Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
