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
    public class ItemTypeSubTypeService :IItemTypeSubTypeService
    {
        private readonly IITemTypeSubTypeRepository _iTemTypeSubTypeRepository;

        public ItemTypeSubTypeService(IITemTypeSubTypeRepository iTemTypeSubTypeRepository)
        {
            _iTemTypeSubTypeRepository = iTemTypeSubTypeRepository;
        }

        public async Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, string ErrorMessage)> Create(ItemTypeSubType itemTypeSubType)
        {
            try
            {
                if(itemTypeSubType.Id.IsNullOrEmpty())
                    _iTemTypeSubTypeRepository.Create(itemTypeSubType);
                _iTemTypeSubTypeRepository.Update(itemTypeSubType);
                await _iTemTypeSubTypeRepository.Save();
                return (true, itemTypeSubType, "Item Type Sub Type Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,new ItemTypeSubType(), e.Message ) ;
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemTypeSubType> itemTypeSubType, string ErrorMessage)> GetAllItemTypeSubType()
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemType)
                    .ToListAsync();
                return result.Count > 0 ? (true, result, "Loaded") : (false, new List<ItemTypeSubType>(), "Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false, new List<ItemTypeSubType>(), e.Message ) ;
            }
        }

        public async Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, string ErrorMessage)> GetItemTypeSubType(Guid Id)
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemType)
                    .FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, result, "Not Found") : (true, result, "Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,new ItemTypeSubType(), e.Message ) ;
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Item Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _iTemTypeSubTypeRepository.Save();
                return (true, Id, "Item Deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,Id, e.Message ) ;
            }
        }
    }
}
