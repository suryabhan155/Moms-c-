using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Interfaces.Persistence;
using Moms.SharedKernel.Response;
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

        public async Task<(bool IsSuccess, PurchaseOrderItem purchaseOrderItem, ResponseModel response)> AddPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem)
        {
            try
            {
                if (purchaseOrderItem == null)
                    return (false, purchaseOrderItem, new ResponseModel { message = "No purchase order item found", data = purchaseOrderItem, code = HttpStatusCode.NotFound });

                if (purchaseOrderItem.Id.IsNullOrEmpty())
                {
                    _purchaseOrderItemRepository.Create(purchaseOrderItem);
                }
                else
                {
                    _purchaseOrderItemRepository.Update(purchaseOrderItem);
                }
                await _purchaseOrderItemRepository.Save();

                return (true, purchaseOrderItem, new ResponseModel { message ="Purchase Order Item created successfully" , data =purchaseOrderItem , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeletePurchaseOrderItem(Guid id)
        {
            try
            {

                var items = await _purchaseOrderItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (items == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = items, code = HttpStatusCode.NotFound });
                items.VoidDate = DateTime.Now;
                items.Void = true;
                _purchaseOrderItemRepository.Update(items);
                await _purchaseOrderItemRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data =items , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error deleting records: Error occurred", e);
                return (false, id, new ResponseModel { message = e.Message, data =id , code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, PurchaseOrderItem purchaseOrderItems, ResponseModel response) GetPurchaseOrderItem(Guid id)
        {
            try
            {
                var result = _purchaseOrderItemRepository.GetById(id);
                return result == null ? (false, new PurchaseOrderItem(), new ResponseModel { message = "No Record Found", data =result , code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Record Found", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Items: Error occurred", e);
                return (false, new PurchaseOrderItem(), new ResponseModel { message =e.Message , data = new PurchaseOrderItem(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PurchaseOrderItem>, ResponseModel response)> LoadPurchaseOrderItems()
        {
            try
            {
                var result = await _purchaseOrderItemRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<PurchaseOrderItem>(), new ResponseModel { message = "PurchaseOrder Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message ="Records Found" , data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Items: Error occurred", e);
                return (false, new List<PurchaseOrderItem>(), new ResponseModel { message = e.Message, data = new List<PurchaseOrderItem>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
