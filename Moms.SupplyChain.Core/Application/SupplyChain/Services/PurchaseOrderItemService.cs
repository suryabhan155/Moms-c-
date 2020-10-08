using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Serilog;

namespace Moms.SupplyChain.Core.Application.SupplyChain.Services
{
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepository;

        public PurchaseOrderItemService(IPurchaseOrderItemRepository iPurchaseOrderItemRepository)
        {
            _purchaseOrderItemRepository = iPurchaseOrderItemRepository;
        }

        public async Task<(bool IsSuccess, PurchaseOrderItem purchaseOrderItem, string ErrorMessage)> AddPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem)
        {
            try
            {
                if (purchaseOrderItem == null)
                    return (false, purchaseOrderItem, "No purchase order item found");

                if (purchaseOrderItem.Id.IsNullOrEmpty())
                {
                    _purchaseOrderItemRepository.Create(purchaseOrderItem);
                }
                else
                {
                    _purchaseOrderItemRepository.Update(purchaseOrderItem);
                }
                await _purchaseOrderItemRepository.Save();

                return (true, purchaseOrderItem, "Purchase Order Item created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeletePurchaseOrderItem(Guid id)
        {
            try
            {

                var items = await _purchaseOrderItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (items == null)
                    return (false, id, "No record found.");
                _purchaseOrderItemRepository.Delete(items);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                Log.Error("Error deleting records: Error occurred", e);
                return (false, id, e.Message);
            }
        }

        public (bool IsSuccess, PurchaseOrderItem purchaseOrderItems, string ErrorMessage) GetPurchaseOrderItem(Guid id)
        {
            try
            {
                var result = _purchaseOrderItemRepository.GetById(id);
                return result == null ? (false, new PurchaseOrderItem(), "No Record Found") : (true, result, "Record Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Items: Error occurred", e);
                return (false, new PurchaseOrderItem(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PurchaseOrderItem>, string ErrorMessage)> LoadPurchaseOrderItems()
        {
            try
            {
                var result = await _purchaseOrderItemRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<PurchaseOrderItem>(), "PurchaseOrder Not Found") : (true, result, "Records Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Items: Error occurred", e);
                return (false, new List<PurchaseOrderItem>(), e.Message);
            }
        }
    }
}
