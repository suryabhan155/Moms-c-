using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IPurchaseOrderItemService
    {
        Task<(bool IsSuccess, IEnumerable<PurchaseOrderItem>, String ErrorMessage)> LoadPurchaseOrderItems();

        (bool IsSuccess, PurchaseOrderItem purchaseOrderItems, String ErrorMessage)
            GetPurchaseOrderItem(Guid id);

        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeletePurchaseOrderItem(Guid id);

        Task<(bool IsSuccess, PurchaseOrderItem purchaseOrderItem, String ErrorMessage)> AddPurchaseOrderItem(
            PurchaseOrderItem purchaseOrderItem);
    }
}
