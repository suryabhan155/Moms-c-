using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Application.Item.Service;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemMasterService
    {
        Task<(bool IsSuccess, ItemMaster itemMaster, ResponseModel model)> Create(ItemMaster itemMaster);
        Task<(bool IsSuccess, IEnumerable<ItemMaster> itemMaster, ResponseModel model)> GetAllItemMaster();
        Task<(bool IsSuccess, ItemMaster itemMaster, ResponseModel model)> GetItemMaster(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
