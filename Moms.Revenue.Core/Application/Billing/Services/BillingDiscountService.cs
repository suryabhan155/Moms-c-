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
    public class BillingDiscountService:IBillingDiscountService
    {
        private readonly IBillingDiscountRepository _billingDiscountRepository;

        public BillingDiscountService(IBillingDiscountRepository billingDiscountRepository)
        {
            _billingDiscountRepository = billingDiscountRepository;
        }

        public async Task<(bool IsSuccess, BillingDiscount billingDiscount, ResponseModel model)> Create(BillingDiscount billingDiscount)
        {
            try
            {
                if(billingDiscount.Id.IsNullOrEmpty())
                    _billingDiscountRepository.Create(billingDiscount);
                else
                    _billingDiscountRepository.Update(billingDiscount);
                await _billingDiscountRepository.Save();
                return (true, billingDiscount, new ResponseModel { message = "Billing Discount Saved", data = billingDiscount, code = HttpStatusCode.OK});
            }
            catch (Exception e)
            {
               Log.Error("Error Saving Billing Discount",e.Message);
               return (false, billingDiscount, new ResponseModel { message = e.Message, data = billingDiscount, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingDiscount> billingDiscounts, ResponseModel model)> GetAllBillingDiscounts()
        {
            try
            {
                var result = _billingDiscountRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Billing Discount(s) Loaded", data = result, code = HttpStatusCode.OK }) : (false, new List<BillingDiscount>(), new ResponseModel { message = "Billing Discount(s) Not Found", data = result, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Billing Discount",e.Message);
                return (false, new List<BillingDiscount>() , new ResponseModel { message = e.Message, data = new List<BillingDiscount>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, BillingDiscount billingDiscount, ResponseModel model)> GetBillingDiscount(Guid Id)
        {
            try
            {
                var result = await _billingDiscountRepository.GetAll(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                if (result == null)
                {
                    return (false, new BillingDiscount(), new ResponseModel { message = "Billing Discount Not Found", data = result, code = HttpStatusCode.NotFound });
                }
                else
                {
                    return result.Id.IsNullOrEmpty() ? (false, new BillingDiscount(), new ResponseModel { message = "Billing Discount Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Billing Discount Loaded", data = result, code = HttpStatusCode.OK });
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Billing Discount",e.Message);
                return (false, new BillingDiscount() , new ResponseModel { message = e.Message, data = new BillingDiscount(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _billingDiscountRepository.GetAll(x => x.Id == Id &&  x.Void == false)
                    .FirstOrDefaultAsync();
                if (result == null)
                {
                    return (false, Id, new ResponseModel { message = "Billing Discount Item Does Not Found", data = Id, code = HttpStatusCode.NotFound });
                }
                else
                {
                    if (result.Id.IsNullOrEmpty())
                    {
                        return (false, Id, new ResponseModel { message = "Billing Discount Item Not Found", data = Id, code = HttpStatusCode.NotFound });
                    }
                    else
                    {
                        result.VoidDate = DateTime.Today;
                        result.Void = true;
                        _billingDiscountRepository.Update(result);
                        await _billingDiscountRepository.Save();
                        return (true, Id, new ResponseModel { message = "Billing Discount Item Deleted", data = Id, code = HttpStatusCode.OK });
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Billing Discount",e.Message);
                return (false, Id, new ResponseModel { message = e.Message, data = Id, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
