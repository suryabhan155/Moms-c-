using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Interfaces.Persistence;
using Serilog;

namespace Moms.Lookup.Core.Application.Options.Service
{

    public class LookupItemService: ILookupItemService
    {
        private readonly ILookupItemRepository _lookupItemRepository;

        public LookupItemService(ILookupItemRepository lookupItemRepository)
        {
            _lookupItemRepository = lookupItemRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupItem> lookupItem, ResponseModel ErrorMessage)> LoadAll()
        {
            try
            {
                //var data = await _lookupItemRepository.GetAll(x => x.Void == false).ToListAsync();
                var data = _lookupItemRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC);
                return (true, data, new ResponseModel {  message = "Lookup Loaded successfully", data = data, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                IEnumerable<LookupItem>  lookupItems=new List<LookupItem>();
                return (false, lookupItems, new ResponseModel {  message = e.Message, data = lookupItems, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, LookupItem lookupItem, ResponseModel ErrorMessage)> GetLookupItem(Guid id)
        {
            try
            {
                var data = await _lookupItemRepository.GetAll(x=>x.Id==id).FirstOrDefaultAsync();
                return (true, data, new ResponseModel {  message = "lookupItem fetched successfully", data = data, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                LookupItem  lookupItems=new LookupItem();
                return (false, lookupItems, new ResponseModel {  message = e.Message, data = lookupItems , code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel ErrorMessage)> DeleteLookupItem(Guid id)
        {
            try
            {
                _lookupItemRepository.DeleteById(id);
                await _lookupItemRepository.Save();
                return (true, id, new ResponseModel {  message = "Record deleted successfully", data = id , code = HttpStatusCode.OK } );
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting : Error occured",e);
                return (false, id, new ResponseModel {  message = e.Message, data = id, code = HttpStatusCode.BadRequest } );
            }
        }

        public async Task<(bool IsSuccess, LookupItem lookupItem, ResponseModel ErrorMessage)> AddLookupItem(LookupItem lookupItem)
        {
            try
            {
                if(lookupItem.Id.IsNullOrEmpty())
                    _lookupItemRepository.Create(lookupItem);
                 else
                    _lookupItemRepository.Update(lookupItem);
                await _lookupItemRepository.Save();

                return (true, lookupItem, new ResponseModel {  message = "LookupItem Added successfully", data = lookupItem , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                return (false, lookupItem, new ResponseModel {  message = e.Message, data = lookupItem , code = HttpStatusCode.BadRequest } );
            }
        }
    }
}
