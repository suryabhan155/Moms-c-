using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class PriceListService:IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListService(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }
        public async Task<(bool IsSuccess, PriceList priceList, string ErrorMessage)> Create(PriceList priceList)
        {
            try
            {
                if(priceList.Id.IsNullOrEmpty())
                    _priceListRepository.Create(priceList);
                _priceListRepository.Update(priceList);
                await _priceListRepository.Save();
                return (true, priceList, "Price List saved");
            }
            catch (Exception e)
            {
                Log.Error("Error saving Price List",e.Message);
                return (false, new PriceList(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PriceList> priceList, string ErrorMessage)> GetAllPriceList()
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Void).ToListAsync();
                return result.Count > 0 ? (true, result, "Price List Loaded") : (false, new List<PriceList>(), "No Price List Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List(s)",e.Message);
                return (false, new List<PriceList>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, PriceList priceList, string ErrorMessage)> GetPriceList(Guid Id)
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Id == Id)
                    .Include(x => x.Items)
                    .Include(x => x.Modules)
                    .Include(x => x.BillingTypes)
                    .Include(x => x.ClientBillingItems)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, result, "Price List Not Found");
                return (true, result, "Price List Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List",e.Message);
                return (false, new PriceList(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _priceListRepository.GetAll(x => x.Id == Id && !x.Void).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Price List Item Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _priceListRepository.Save();
                return (true, Id, "Price List Item Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Price List",e.Message);
                return (false,Id, e.Message);
            }
        }
    }
}
