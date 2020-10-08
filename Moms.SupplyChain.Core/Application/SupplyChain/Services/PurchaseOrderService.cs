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
    public class PurchaseOrderService:IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _iPurchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository iPurchaseOrderRepository)
        {
            _iPurchaseOrderRepository = iPurchaseOrderRepository;
        }

        public async Task<(bool IsSuccess, PurchaseOrder purchaseOrder, string ErrorMessage)> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                if (purchaseOrder == null)
                    return (false, purchaseOrder, "No purchase order found.");

                if(purchaseOrder.Id.IsNullOrEmpty())
                    _iPurchaseOrderRepository.Create(purchaseOrder);
                else
                {
                    _iPurchaseOrderRepository.Update(purchaseOrder);
                }

                await _iPurchaseOrderRepository.Save();

                return (true, purchaseOrder, "Purchase order save successfully.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeletePurchaseOrder(Guid id)
        {
            try
            {
                var purchaseOrder = await _iPurchaseOrderRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (purchaseOrder == null)
                    return (false, id, "No record found");

                _iPurchaseOrderRepository.Delete(purchaseOrder);

                return (false, id, "Record deleted successfully.");

            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, PurchaseOrder purchaseOrders, string ErrorMessage) GetPurchaseOrder(Guid id)
        {
            try
            {

                var purchaseOrder = _iPurchaseOrderRepository.GetById(id);
                if (purchaseOrder == null)
                    return (false, null, "Purchase order not found.");
                return (true, purchaseOrder, "Purchase order loaded successfully");

            }
            catch (Exception e)
            {

                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PurchaseOrder>, string ErrorMessage)> LoadPurchaseOrders()
        {
            try
            {
                var result = await _iPurchaseOrderRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<PurchaseOrder>(), "No Record Found") : (true, result, "Records Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Orders: Error occurred", e);
                return (false, new List<PurchaseOrder>(), e.Message);

            }
        }
    }
}
