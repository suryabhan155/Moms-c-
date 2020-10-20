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
    public class BillingDiscountService:IBillingDiscountService
    {
        private readonly IBillingDiscountRepository _billingDiscountRepository;

        public BillingDiscountService(IBillingDiscountRepository billingDiscountRepository)
        {
            _billingDiscountRepository = billingDiscountRepository;
        }

        public async Task<(bool IsSuccess, BillingDiscount billingDiscount, string ErrorMessage)> Create(BillingDiscount billingDiscount)
        {
            try
            {
                if(billingDiscount.Id.IsNullOrEmpty())
                    _billingDiscountRepository.Create(billingDiscount);
                _billingDiscountRepository.Update(billingDiscount);
                await _billingDiscountRepository.Save();
                return (true, billingDiscount, "Billing Discount Saved");
            }
            catch (Exception e)
            {
               Log.Error("Error Saving Billing Discount",e.Message);
               return (false, billingDiscount, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingDiscount> billingDiscounts, string ErrorMessage)> GetAllBillingDiscounts()
        {
            try
            {
                var result = await _billingDiscountRepository.GetAll().ToListAsync();
                return result.Count > 0 ? (true, result, "Billing Discount(s) Loaded") : (false, new List<BillingDiscount>(), "Billing Discount(s) Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Billing Discount",e.Message);
                return (false, new List<BillingDiscount>() , e.Message);
            }
        }

        public async Task<(bool IsSuccess, BillingDiscount billingDiscount, string ErrorMessage)> GetBillingDiscount(Guid Id)
        {
            try
            {
                var result = await _billingDiscountRepository.GetAll(x => x.Id == Id && !x.Void)
                    .FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, new BillingDiscount(), "Billing Discount Not Found") : (true, result, "Billing Discount Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Billing Discount",e.Message);
                return (false, new BillingDiscount() , e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _billingDiscountRepository.GetAll(x => x.Id == Id && !x.Void)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Billing Discount Item Not Found");
                result.VoidDate=DateTime.Today;
                result.Void = true;
                return (true, Id, "Billing Discount Item Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Billing Discount",e.Message);
                return (false, Id, e.Message);
            }
        }
    }
}
