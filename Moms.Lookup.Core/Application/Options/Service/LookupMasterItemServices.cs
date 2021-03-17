using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Application.Options.Response;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options;
using Moms.Lookup.Core.Domain.Options.Dto;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Moms.SharedKernel.Interfaces.Persistence;
using Serilog;

namespace Moms.Lookup.Core.Application.Options.Service
{
    public class LookupMasterItemServices: ILookupMasterItemService
    {
        private readonly ILookupMasterItemRepository _lookupOptionsRepository;
        private readonly ILookupItemRepository _lookupItemRepository;
        private readonly ILookupMasterRepository _lookupMasterRepository;
        private readonly ICountyLookupRepository _countyLookupRepository;

        public LookupMasterItemServices(ILookupMasterItemRepository lookupOptionsRepository, ILookupItemRepository lookupItemRepository,
            ILookupMasterRepository lookupMasterRepository, ICountyLookupRepository countyLookupRepository)
        {
            _lookupOptionsRepository = lookupOptionsRepository;
            _lookupMasterRepository = lookupMasterRepository;
            _lookupItemRepository = lookupItemRepository;
            _countyLookupRepository = countyLookupRepository;
        }

        public async Task<(bool IsSuccess, LookupMasterItem lookupOption, ResponseModel model)> AddLookupMasterItem(LookupMasterItem lookupOption)
        {
            try
            {
                _lookupOptionsRepository.Create(lookupOption);
                await _lookupOptionsRepository.Save();
                return (true, lookupOption, new ResponseModel { message = "LookupOption added successfully", data = lookupOption, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Adding LookupOptions : Error occured", e);
                return (false, lookupOption, new ResponseModel { message = e.Message, data = lookupOption, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteLookupOption(Guid id)
        {
            try
            {
                _lookupOptionsRepository.DeleteById(id);
                await _lookupOptionsRepository.Save();
                return (true, id, new ResponseModel { message = "LookupOption deleted successfully", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting lookupOptions : Error occured", e);
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetAllCounty()
        {
            try
            {
                //var result = await _countyLookupRepository.GetAll().ToListAsync();
                var result = _countyLookupRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC);
                return result == null ? (false, new List<CountyLookup>(), new ResponseModel { message = "Counties Not Found", data = new List<CountyLookup>(), code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "LookupOption deleted successfully", data = new List<CountyLookup>(), code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Adding LookupOptions : Error occured", e);
                return (false, new List<CountyLookup>(), new ResponseModel { message = e.Message, data = new List<CountyLookup>(), code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetCounty(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.CountyName == name.ToUpper())
                    .ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), new ResponseModel { message = "County not found", data = new List<CountyLookup>(), code = HttpStatusCode.NotFound });
                return (true, result, new ResponseModel { message = "county loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading County : Error occured", e);
                return (false, new List<CountyLookup>(), new ResponseModel { message = e.Message, data = new List<CountyLookup>(), code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetSubCounty(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.SubCountyName == name.ToUpper())
                    .ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), new ResponseModel { message = "Error in loading SubCounty", data = new List<CountyLookup>(), code = HttpStatusCode.BadRequest });
                return (true, result, new ResponseModel { message = "SubCounty loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading County : Error occured", e);
                return (false, new List<CountyLookup>(), new ResponseModel { message = e.Message, data = new List<CountyLookup>(), code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<CountyLookup> CountyLookup, ResponseModel model)> GetWards(string name)
        {
            try
            {
                var result = await _countyLookupRepository.GetAll(x => x.WardName == name.ToUpper()).ToListAsync();
                if (result == null)
                    return (false, new List<CountyLookup>(), new ResponseModel { message = "No Wards Found", data = new List<CountyLookup>(), code = HttpStatusCode.NotFound });
                return (true, result, new ResponseModel { message = "Wards Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Wards : Error occured", e);
                return (false, new List<CountyLookup>(), new ResponseModel { message = e.Message, data = new List<CountyLookup>(), code = HttpStatusCode.BadRequest });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LookupMasterItem> lookupMasterItems, ResponseModel model)> LoadAll()
        {
            try
            {
                var data = await _lookupOptionsRepository.GetAll().ToListAsync();
                return (true, data, new ResponseModel { message = "LookupOptions loaded successfully", data = data, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading lookupOptions : Error occured",e);
                IEnumerable<LookupMasterItem>  lookupOption=new List<LookupMasterItem>();
                return (false, lookupOption, new ResponseModel { message = e.Message, data = lookupOption, code = HttpStatusCode.BadRequest });
            }
        }
    }
}
