using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IPurchaseOrderItemService
    {
        Task<(bool IsSuccess, IEnumerable<PurchaseOrderItem>, ResponseModel response)> LoadPurchaseOrderItems();

        (bool IsSuccess, PurchaseOrderItem purchaseOrderItems, ResponseModel response)
            GetPurchaseOrderItem(Guid id);

        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeletePurchaseOrderItem(Guid id);

        Task<(bool IsSuccess, PurchaseOrderItem purchaseOrderItem, ResponseModel response)> AddPurchaseOrderItem(
            PurchaseOrderItem purchaseOrderItem);
    }
}
