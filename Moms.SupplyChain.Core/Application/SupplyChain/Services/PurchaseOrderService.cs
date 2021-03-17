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
    public class PurchaseOrderService:IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _iPurchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository iPurchaseOrderRepository)
        {
            _iPurchaseOrderRepository = iPurchaseOrderRepository;
        }

        public async Task<(bool IsSuccess, PurchaseOrder purchaseOrder, ResponseModel response)> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                if (purchaseOrder == null)
                    return (false, purchaseOrder, new ResponseModel { message = "No purchase order found.", data = purchaseOrder, code = HttpStatusCode.NotFound });

                if(purchaseOrder.Id.IsNullOrEmpty())
                    _iPurchaseOrderRepository.Create(purchaseOrder);
                else
                {
                    _iPurchaseOrderRepository.Update(purchaseOrder);
                }

                await _iPurchaseOrderRepository.Save();

                return (true, purchaseOrder, new ResponseModel { message = "Purchase order save successfully.", data = purchaseOrder, code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeletePurchaseOrder(Guid id)
        {
            try
            {
                var purchaseOrder = await _iPurchaseOrderRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (purchaseOrder == null)
                    return (false, id, new ResponseModel { message ="No record found" , data =purchaseOrder , code = HttpStatusCode.NotFound });
                purchaseOrder.VoidDate = DateTime.Now;
                purchaseOrder.Void = true;
                _iPurchaseOrderRepository.Update(purchaseOrder);
                await _iPurchaseOrderRepository.Save();
                return (true, id, new ResponseModel { message = "Record deleted successfully.", data =purchaseOrder , code = HttpStatusCode.OK });

            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data =id , code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, PurchaseOrder purchaseOrders, ResponseModel response) GetPurchaseOrder(Guid id)
        {
            try
            {
                var purchaseOrder = _iPurchaseOrderRepository.GetById(id);
                if (purchaseOrder == null)
                    return (false, null, new ResponseModel { message = "Purchase order not found.", data = purchaseOrder, code = HttpStatusCode.NotFound });
                return (true, purchaseOrder, new ResponseModel { message ="Purchase order loaded successfully" , data = purchaseOrder, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.NotFound });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PurchaseOrder>, ResponseModel response)> LoadPurchaseOrders()
        {
            try
            {
                var result =await _iPurchaseOrderRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<PurchaseOrder>(), new ResponseModel { message = "No Record Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Records Found", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Purchase Orders: Error occurred", e);
                return (false, new List<PurchaseOrder>(), new ResponseModel { message = e.Message, data =new List<PurchaseOrder>() , code = HttpStatusCode.InternalServerError } );
            }
        }
    }
}
