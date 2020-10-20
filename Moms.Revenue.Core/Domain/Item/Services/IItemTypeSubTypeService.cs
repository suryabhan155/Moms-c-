using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemTypeSubTypeService
    {
        Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, string ErrorMessage)> Create(ItemTypeSubType itemTypeSubType);
        Task<(bool IsSuccess, IEnumerable<ItemTypeSubType> itemTypeSubType, string ErrorMessage)> GetAllItemTypeSubType();
        Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, string ErrorMessage)> GetItemTypeSubType(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
