using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;
using Moms.SharedKernel.Response;
using System.Net;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ItemTypeService: IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;

        public ItemTypeService(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }
        public async Task<(bool IsSuccess, ItemType itemType, ResponseModel model)> Create(ItemType itemType)
        {
            try
            {
                if(itemType.Id.IsNullOrEmpty())
                    _itemTypeRepository.Create(itemType);
                _itemTypeRepository.Update(itemType);
                await _itemTypeRepository.Save();
                return (true, itemType, new ResponseModel { message = "Item Type Saved", data = itemType , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Item Type",e.Message);
                return(false, itemType, new ResponseModel { message = e.Message, data = itemType , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemType> itemType, ResponseModel model)> GetAllItemType()
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemTypeSubType)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message ="Item Type Loaded" , data = result , code = HttpStatusCode.OK });
                return (false, new List<ItemType>(), new ResponseModel { message = "Item Type Not Found", data = new List<ItemType>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Item Type",e.Message);
                return(false, new List<ItemType>(), new ResponseModel { message =e.Message , data = new List<ItemType>(), code = HttpStatusCode.InternalServerError } );
            }
        }

        public async Task<(bool IsSuccess, ItemType itemType, ResponseModel model)> GetItemType(Guid Id)
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemTypeSubType)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, result, new ResponseModel { message = "Item Type Not Found", data = result , code = HttpStatusCode.NotFound });
                return (true, result, new ResponseModel { message = "Item Type Loaded", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Item Type",e.Message);
                return(false, new ItemType(), new ResponseModel { message = e.Message, data = new ItemType(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _itemTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Item Type Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _itemTypeRepository.Save();
                return (true, Id, new ResponseModel { message = "Item Type Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Item Type",e.Message);
                return(false, Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
