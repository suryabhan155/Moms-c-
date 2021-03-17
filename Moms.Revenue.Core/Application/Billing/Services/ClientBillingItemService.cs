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

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class ClientBillingItemService:IClientBillingItemService
    {
        private readonly IClientBillingItemRepository _clientBillingItemRepository;

        public ClientBillingItemService(IClientBillingItemRepository clientBillingItemRepository)
        {
            _clientBillingItemRepository = clientBillingItemRepository;
        }

        public async Task<(bool IsSuccess, ClientBillingItem clientBillingItem, ResponseModel model)> Create(ClientBillingItem clientBillingItem)
        {
            try
            {
                if(clientBillingItem.Id.IsNullOrEmpty())
                    _clientBillingItemRepository.Create(clientBillingItem);
                else
                    _clientBillingItemRepository.Update(clientBillingItem);
                await _clientBillingItemRepository.Save();
                return (true, clientBillingItem, new ResponseModel { message = "Client Billing Item Saved Successfully", data = clientBillingItem , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill Item",e);
                return (false, clientBillingItem, new ResponseModel { message = e.Message, data = clientBillingItem , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillingItem> clientBillingItem, ResponseModel model)> GetAllClientBillingItem()
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll(x=>!x.Void).ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Client Billing Item Loaded", data = result , code = HttpStatusCode.OK });
                return (false, new List<ClientBillingItem>(), new ResponseModel { message = "Client Billing Item Not Found", data = result, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Client Bill",e);
                return (false,new List<ClientBillingItem>() , new ResponseModel { message = e.Message, data = new List<ClientBillingItem>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillingItem> clientBillingItem, ResponseModel model)> GetClientBillingItem(Guid Id)
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll(x => x.BillId == Id).ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Client Billing Item(s) Found", data = result , code = HttpStatusCode.OK }) : (false, new List<ClientBillingItem>(), new ResponseModel { message = "Client Billing Item(s) Not Found", data = new List<ClientBillingItem>(), code = HttpStatusCode.NotFound } );
            }
            catch (Exception e)
            {
                Log.Error("No Client Bill Item Found");
                return (false, new List<ClientBillingItem>(), new ResponseModel { message =e.Message , data = new List<ClientBillingItem>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll(x => x.Id == Id && !x.Void).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Client Bill Item Not Found", data = Id, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Client Bill Item Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _clientBillingItemRepository.Save();
                return (true, Id, new ResponseModel { message = "Client Bill Item Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("No Client Bill Item Found");
                return (false, Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
