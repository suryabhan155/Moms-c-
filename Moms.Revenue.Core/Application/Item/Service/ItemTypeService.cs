using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ItemTypeService: IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;

        public ItemTypeService(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }
        public async Task<(bool IsSuccess, ItemType itemType, string ErrorMessage)> Create(ItemType itemType)
        {
            try
            {
                if(itemType.Id.IsNullOrEmpty())
                    _itemTypeRepository.Create(itemType);
                _itemTypeRepository.Update(itemType);
                await _itemTypeRepository.Save();
                return (true, itemType, "Item Type Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Item Type",e.Message);
                return(false, itemType,e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemType> itemType, string ErrorMessage)> GetAllItemType()
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemTypeSubType)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Item Type Loaded");
                return (false, new List<ItemType>(), "Item Type Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Item Type",e.Message);
                return(false, new List<ItemType>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, ItemType itemType, string ErrorMessage)> GetItemType(Guid Id)
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemTypeSubType)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, result, "Item Type Not Found");
                return (true, result, "Item Type Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Item Type",e.Message);
                return(false, new ItemType(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Item Type Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _itemTypeRepository.Save();
                return (true, Id, "Item Type Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Item Type",e.Message);
                return(false, Id, e.Message);
            }
        }
    }
}
