using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IPurchaseOrderService
    {
        Task<(bool IsSuccess, IEnumerable<PurchaseOrder>, String ErrorMessage)> LoadPurchaseOrders();

        (bool IsSuccess, PurchaseOrder purchaseOrders, String ErrorMessage) GetPurchaseOrder(Guid id);

        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeletePurchaseOrder(Guid id);

        Task<(bool IsSuccess, PurchaseOrder purchaseOrder, String ErrorMessage)> AddPurchaseOrder(
            PurchaseOrder purchaseOrder);
    }
}
