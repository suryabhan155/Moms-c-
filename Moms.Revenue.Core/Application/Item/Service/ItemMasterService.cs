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
    public class ItemMasterService:IItemMasterService
    {
        private readonly IItemMasterRepository _itemMasterRepository;

        public ItemMasterService(IItemMasterRepository itemMasterRepository)
        {
            _itemMasterRepository = itemMasterRepository;
        }

        public async Task<(bool IsSuccess, ItemMaster itemMaster, string ErrorMessage)> Create(ItemMaster itemMaster)
        {
            try
            {
                if (itemMaster.Id.IsNullOrEmpty())
                    _itemMasterRepository.Create(itemMaster);
                _itemMasterRepository.Update(itemMaster);
                await _itemMasterRepository.Save();
                return (true, itemMaster, "Item Master Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Item Master",e.Message);
                return(false,new ItemMaster(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemMaster> itemMaster, string ErrorMessage)> GetAllItemMaster()
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => !x.Void)
                    .Include(x=>x.ItemConfiguration)
                    .Include(x=>x.ItemTypes)
                    .Include(x=>x.ClientBillPayments)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Item Master Loaded");
                return (false, new List<ItemMaster>(), "Item Master Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,new List<ItemMaster>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, ItemMaster itemMaster, string ErrorMessage)> GetItemMaster(Guid Id)
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => x.Id==Id)
                    .Include(x => x.ItemConfiguration)
                    .Include(x => x.ItemTypes)
                    .Include(x => x.ClientBillPayments)
                    .Include(x => x.ItemTypeSubTypes)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, new ItemMaster(), "Item Master Not Found");
                return (true, result, "Item Master Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,new ItemMaster(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Item Master Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                return (true, Id, "Item Master Delete");
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,Id, e.Message);
            }
        }
    }
}
