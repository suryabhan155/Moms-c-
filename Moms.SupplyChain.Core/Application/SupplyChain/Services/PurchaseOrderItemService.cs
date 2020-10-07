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

namespace Moms.SupplyChain.Core.Application.SupplyChain.Services
{
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {

        private readonly IMapper _mapper;
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepository;

        public PurchaseOrderItemService(IMapper iMapper, IPurchaseOrderItemRepository iPurchaseOrderItemRepository)
        {
            _mapper = iMapper;
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
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, PurchaseOrderItem purchaseOrderItems, string ErrorMessage) GetPurchaseOrderItem(Guid id)
        {
            try
            {

                var purchaseOrderItem = _purchaseOrderItemRepository.GetById(id);

                if (purchaseOrderItem == null)
                    return (false, null, "Purchase order items not found.");

                return (true, purchaseOrderItem, "Purchase order items loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PurchaseOrderItem>, string ErrorMessage)> LoadPurchaseOrderItems()
        {
            try
            {
                var purchaseOrderItems = await _purchaseOrderItemRepository.GetAll().ToListAsync();
                return (true, _mapper.Map<List<PurchaseOrderItem>>(purchaseOrderItems),
                    purchaseOrderItems.Count + " items loaded successfully.");

            }
            catch (Exception e)
            {
                IEnumerable<PurchaseOrderItem> purchaseOrderItems = new List<PurchaseOrderItem>();
                return (false, purchaseOrderItems, e.Message);
            }
        }
    }
}
