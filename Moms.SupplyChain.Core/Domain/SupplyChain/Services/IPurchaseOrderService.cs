using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IPurchaseOrderService
    {
        Task<(bool IsSuccess, IEnumerable<PurchaseOrder>, ResponseModel response)> LoadPurchaseOrders();

        (bool IsSuccess, PurchaseOrder purchaseOrders, ResponseModel response) GetPurchaseOrder(Guid id);

        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeletePurchaseOrder(Guid id);

        Task<(bool IsSuccess, PurchaseOrder purchaseOrder, ResponseModel response)> AddPurchaseOrder(
            PurchaseOrder purchaseOrder);
    }
}
