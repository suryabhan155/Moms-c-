using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
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

        public async Task<(bool IsSuccess, IEnumerable<LookupItem> lookupItem, string ErrorMessage)> LoadAll()
        {
            try
            {
                var data = await _lookupItemRepository.GetAll(x => !x.Void).ToListAsync();
                return (true, data, "Lookup Loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                IEnumerable<LookupItem>  lookupItems=new List<LookupItem>();
                return (false, lookupItems, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupItem lookupItem, string ErrorMessage)> GetLookupItem(Guid id)
        {
            try
            {
                var data = await _lookupItemRepository.GetAll(x=>x.Id==id).FirstOrDefaultAsync();
                return (true, data, "lookupItem fetched successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                LookupItem  lookupItems=new LookupItem("");
               return (false, lookupItems, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLookupItem(Guid id)
        {
            try
            {
                _lookupItemRepository.DeleteById(id);
                await _lookupItemRepository.Save();
                return (true, id, "Record deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting : Error occured",e);
                return (false, id, e.Message);
            }
        }

        public async Task<(bool IsSuccess, LookupItem lookupItem, string ErrorMEssage)> AddLookupItem(LookupItem lookupItem)
        {
            try
            {
                _lookupItemRepository.Create(lookupItem);
                await _lookupItemRepository.Save();
                return (true, lookupItem, "LookupItem Added successfully");
            }
            catch (Exception e)
            {
                Log.Error("LookupMaster Load: Error occured",e);
                return (false, lookupItem, e.Message);
            }
        }
    }
}
