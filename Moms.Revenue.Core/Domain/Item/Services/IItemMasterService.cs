using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Application.Item.Service;
using Moms.Revenue.Core.Domain.Item.Models;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemMasterService
    {
        Task<(bool IsSuccess, ItemMaster itemMaster, string ErrorMessage)> Create(ItemMaster itemMaster);
        Task<(bool IsSuccess, IEnumerable<ItemMaster> itemMaster, string ErrorMessage)> GetAllItemMaster();
        Task<(bool IsSuccess, ItemMaster itemMaster, string ErrorMessage)> GetItemMaster(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
