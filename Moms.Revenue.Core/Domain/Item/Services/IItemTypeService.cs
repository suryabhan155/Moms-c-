using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemTypeService
    {
        Task<(bool IsSuccess, ItemType itemType, string ErrorMessage)> Create(ItemType itemType);
        Task<(bool IsSuccess, IEnumerable<ItemType> itemType, string ErrorMessage)> GetAllItemType();
        Task<(bool IsSuccess, ItemType itemType, string ErrorMessage)> GetItemType(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
