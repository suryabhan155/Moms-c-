using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemTypeSubTypeService
    {
        Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, ResponseModel model)> Create(ItemTypeSubType itemTypeSubType);
        Task<(bool IsSuccess, IEnumerable<ItemTypeSubType> itemTypeSubType, ResponseModel model)> GetAllItemTypeSubType();
        Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, ResponseModel model)> GetItemTypeSubType(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
