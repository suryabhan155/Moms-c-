using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;
using Moms.SharedKernel.Response;
using System.Net;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class PriceListService:IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListService(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }
        public async Task<(bool IsSuccess, PriceList priceList, ResponseModel model)> Create(PriceList priceList)
        {
            try
            {
                if(priceList.Id.IsNullOrEmpty())
                    _priceListRepository.Create(priceList);
                else
                    _priceListRepository.Update(priceList);
                await _priceListRepository.Save();
                return (true, priceList, new ResponseModel { message = "Price List saved", data = priceList , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error saving Price List",e.Message);
                return (false, new PriceList(), new ResponseModel { message = e.Message, data = new PriceList(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PriceList> priceList, ResponseModel model)> GetAllPriceList()
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Void).ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Price List Loaded", data = result , code = HttpStatusCode.OK }) : (false, new List<PriceList>(), new ResponseModel { message = "No Price List Found", data = new List<PriceList>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List(s)",e.Message);
                return (false, new List<PriceList>(), new ResponseModel { message = e.Message, data = new List<PriceList>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, PriceList priceList, ResponseModel model)> GetPriceList(Guid Id)
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.ItemMaster)
                    .Include(x => x.Module)
                    .Include(x => x.BillingType)
                    .Include(x => x.ClientBillingItems)
                    .FirstOrDefaultAsync();
                if(result == null)
                    return (false, result, new ResponseModel { message = "Price List Not Found", data = result , code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, result, new ResponseModel { message = "Price List Not Found", data = result , code = HttpStatusCode.NotFound });
                return (true, result, new ResponseModel { message = "Price List Found", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List",e.Message);
                return (false, new PriceList(), new ResponseModel { message = e.Message, data = new PriceList(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Id == Id && !x.Void).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Price List Item Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _priceListRepository.Save();
                return (true, Id, new ResponseModel { message = "Price List Item Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Price List",e.Message);
                return (false,Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
