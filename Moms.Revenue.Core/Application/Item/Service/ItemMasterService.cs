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
    public class ItemMasterService:IItemMasterService
    {
        private readonly IItemMasterRepository _itemMasterRepository;

        public ItemMasterService(IItemMasterRepository itemMasterRepository)
        {
            _itemMasterRepository = itemMasterRepository;
        }

        public async Task<(bool IsSuccess, ItemMaster itemMaster, ResponseModel model)> Create(ItemMaster itemMaster)
        {
            try
            {
                if (itemMaster.Id.IsNullOrEmpty())
                    _itemMasterRepository.Create(itemMaster);
                _itemMasterRepository.Update(itemMaster);
                await _itemMasterRepository.Save();
                return (true, itemMaster, new ResponseModel { message = "Item Master Saved", data = itemMaster , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Item Master",e.Message);
                return(false,new ItemMaster(), new ResponseModel { message = e.Message, data = new ItemMaster(), code = HttpStatusCode.InternalServerError } );
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemMaster> itemMaster, ResponseModel model)> GetAllItemMaster()
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => !x.Void)
                    .Include(x=>x.ItemConfiguration)
                    .Include(x=>x.ItemType)
                    .Include(x=>x.ItemTypeSubType)
                    .Include(x=>x.ClientBillPayments)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Item Master Loaded", data = result , code = HttpStatusCode.OK });
                return (false, new List<ItemMaster>(), new ResponseModel { message = "Item Master Not Found", data = new List<ItemMaster>(), code = HttpStatusCode.NotFound } );
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,new List<ItemMaster>(), new ResponseModel { message = e.Message, data = new List<ItemMaster>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, ItemMaster itemMaster, ResponseModel model)> GetItemMaster(Guid Id)
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => x.Id==Id)
                    .Include(x => x.ItemConfiguration)
                    .Include(x => x.ItemType)
                    .Include(x => x.ClientBillPayments)
                    .Include(x => x.ItemTypeSubType)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, new ItemMaster(), new ResponseModel { message = "Item Master Not Found", data = new ItemMaster(), code = HttpStatusCode.NotFound });
                return (true, result, new ResponseModel { message = "Item Master Loaded", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,new ItemMaster(), new ResponseModel { message = e.Message, data = new ItemMaster(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _itemMasterRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message ="Item Master Not Found" , data = Id , code = HttpStatusCode.NotFound } );
                result.Void = true;
                result.VoidDate=DateTime.Today;
                return (true, Id, new ResponseModel { message = "Item Master Delete", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master",e.Message);
                return(false,Id, new ResponseModel { message =e.Message , data = Id, code = HttpStatusCode.InternalServerError } );
            }
        }
    }
}
