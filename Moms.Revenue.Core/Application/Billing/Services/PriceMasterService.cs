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
using Moms.SharedKernel.Interfaces.Persistence;
using System.Linq;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class PriceMasterService:IPriceMasterService
    {
        private readonly IPriceMasterRepository _priceMasterRepository;

        public PriceMasterService(IPriceMasterRepository priceMasterRepository)
        {
            _priceMasterRepository = priceMasterRepository;
        }
        public async Task<(bool IsSuccess, PriceMaster price, ResponseModel model)> Create(PriceMaster price)
        {
            try
            {
                if(price.Id.IsNullOrEmpty())
                    _priceMasterRepository.Create(price);
                else
                    _priceMasterRepository.Update(price);
                await _priceMasterRepository.Save();
                return (true, price, new ResponseModel { message = "Price List saved", data = price , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error saving Price List",e.Message);
                return (false, new PriceMaster(), new ResponseModel { message = e.Message, data = new PriceMaster(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, PriceMaster price, ResponseModel model)> GetPriceMaster(Guid Id)
        {
            try
            {
                var result = await _priceMasterRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if(result == null)
                    return (false, result, new ResponseModel { message = "Price List Not Found", data = result , code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, result, new ResponseModel { message = "Price List Not Found", data = result , code = HttpStatusCode.NotFound });
                else
                    return (true, result, new ResponseModel { message = "Price List Found", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List",e.Message);
                return (false, new PriceMaster(), new ResponseModel { message = e.Message, data = new PriceMaster(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _priceMasterRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Price List Item Not Found", data = Id , code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Price List Item Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    result.Void = true;
                    result.VoidDate = DateTime.Today;
                    _priceMasterRepository.Update(result);
                    await _priceMasterRepository.Save();
                    return (true, Id, new ResponseModel { message = "Price List Item Deleted", data = Id, code = HttpStatusCode.InternalServerError });
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Price List",e.Message);
                return (false,Id, new ResponseModel { message =e.Message , data = Id , code = HttpStatusCode.InternalServerError } );
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PriceMaster> price, ResponseModel model)> GetAllPriceMaster()
        {
            try
            {
                //var result = await _priceMasterRepository.GetAll(x => x.Void == false).ToListAsync();
                var result =_priceMasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Price List Loaded", data = result , code = HttpStatusCode.OK }) : (false, new List<PriceMaster>(), new ResponseModel { message = "No Price List Found", data = new List<PriceMaster>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Price List(s)", e.Message);
                return (false, new List<PriceMaster>(), new ResponseModel { message = e.Message, data = new List<PriceMaster>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
