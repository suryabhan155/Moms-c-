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
    public class ItemTypeSubTypeService :IItemTypeSubTypeService
    {
        private readonly IITemTypeSubTypeRepository _iTemTypeSubTypeRepository;

        public ItemTypeSubTypeService(IITemTypeSubTypeRepository iTemTypeSubTypeRepository)
        {
            _iTemTypeSubTypeRepository = iTemTypeSubTypeRepository;
        }

        public async Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, ResponseModel model)> Create(ItemTypeSubType itemTypeSubType)
        {
            try
            {
                if(itemTypeSubType.Id.IsNullOrEmpty())
                    _iTemTypeSubTypeRepository.Create(itemTypeSubType);
                _iTemTypeSubTypeRepository.Update(itemTypeSubType);
                await _iTemTypeSubTypeRepository.Save();
                return (true, itemTypeSubType, new ResponseModel { message = "Item Type Sub Type Saved", data = itemTypeSubType , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,new ItemTypeSubType(), new ResponseModel { message = e.Message, data = new ItemTypeSubType(), code = HttpStatusCode.InternalServerError } ) ;
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemTypeSubType> itemTypeSubType, ResponseModel model)> GetAllItemTypeSubType()
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemType)
                    .ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message ="Loaded" , data = result , code = HttpStatusCode.OK }) : (false, new List<ItemTypeSubType>(), new ResponseModel { message ="Not Found" , data = new List<ItemTypeSubType>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false, new List<ItemTypeSubType>(), new ResponseModel { message = e.Message, data = new List<ItemTypeSubType>(), code = HttpStatusCode.InternalServerError } ) ;
            }
        }

        public async Task<(bool IsSuccess, ItemTypeSubType itemTypeSubType, ResponseModel model)> GetItemTypeSubType(Guid Id)
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.ItemType)
                    .FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, result, new ResponseModel { message = "Not Found", data = result , code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message ="Loaded" , data = result , code = HttpStatusCode.OK } );
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,new ItemTypeSubType(), new ResponseModel { message = e.Message, data = new ItemTypeSubType(), code = HttpStatusCode.InternalServerError } ) ;
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _iTemTypeSubTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Item Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _iTemTypeSubTypeRepository.Save();
                return (true, Id, new ResponseModel { message = "Item Deleted successfully", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Saving Item Type Sub Type",e.Message);
                return(false,Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError } ) ;
            }
        }
    }
}
