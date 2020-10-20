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
    public class ClientBillingItemService:IClientBillingItemService
    {
        private readonly IClientBillingItemRepository _clientBillingItemRepository;

        public ClientBillingItemService(IClientBillingItemRepository clientBillingItemRepository)
        {
            _clientBillingItemRepository = clientBillingItemRepository;
        }

        public async Task<(bool IsSuccess, ClientBillingItem clientBillingItem, string ErrorMessage)> Create(ClientBillingItem clientBillingItem)
        {
            try
            {
                if(clientBillingItem.Id.IsNullOrEmpty())
                    _clientBillingItemRepository.Create(clientBillingItem);
                _clientBillingItemRepository.Update(clientBillingItem);
                await _clientBillingItemRepository.Save();
                return (true, clientBillingItem, "Client Billing Item Saved Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Client Bill Item",e);
                return (false, clientBillingItem, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillingItem> clientBillingItem, string ErrorMessage)> GetAllClientBillingItem()
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll().ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Client Billing Item Loaded");
                return (false, new List<ClientBillingItem>(), "Client Billing Item Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Client Bill",e);
                return (false,new List<ClientBillingItem>() , e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ClientBillingItem> clientBillingItem, string ErrorMessage)> GetClientBillingItem(Guid Id)
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll(x => x.BillId == Id).ToListAsync();
                return result.Count > 0 ? (true, result, "Client Billing Item(s) Found") : (false, new List<ClientBillingItem>(), "Client Billing Item(s) Not Found");
            }
            catch (Exception e)
            {
                Log.Error("No Client Bill Item Found");
                return (false, new List<ClientBillingItem>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _clientBillingItemRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Client Bill Item Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _clientBillingItemRepository.Save();
                return (true, Id, "Client Bill Item Deleted");
            }
            catch (Exception e)
            {
                Log.Error("No Client Bill Item Found");
                return (false, Id, e.Message);
            }
        }
    }
}
