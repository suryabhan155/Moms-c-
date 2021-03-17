using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemTypeService
    {
        Task<(bool IsSuccess, ItemType itemType, ResponseModel model)> Create(ItemType itemType);
        Task<(bool IsSuccess, IEnumerable<ItemType> itemType, ResponseModel model)> GetAllItemType();
        Task<(bool IsSuccess, ItemType itemType, ResponseModel model)> GetItemType(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
