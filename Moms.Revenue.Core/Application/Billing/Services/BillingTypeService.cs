using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class BillingTypeService: IBillingTypeService
    {
        private readonly IBillingTypeRepository _billingTypeRepository;

        public BillingTypeService(IBillingTypeRepository billingTypeRepository)
        {
            _billingTypeRepository = billingTypeRepository;
        }

        public async Task<(bool IsSuccess, BillingType billingType, string ErrorMessage)> Create(BillingType billingType)
        {
            try
            {
                if(billingType.Id.IsNullOrEmpty())
                    _billingTypeRepository.Create(billingType);
                _billingTypeRepository.Update(billingType);
                await _billingTypeRepository.Save();
                return (true, billingType, "Billing Type Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Billing Type",e.Message);
                return (false, billingType, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingType> itemConfiguration, string ErrorMessage)> GetAllBillingType()
        {
            try
            {
                var result = await _billingTypeRepository.GetAll().ToListAsync();
                return result.Count > 0 ? (true, result, "Billing Loaded") : (false, new List<BillingType>(), "Billing Types Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error loading Billing Type",e.Message);
                return (false, new List<BillingType>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, BillingType itemConfiguration, string ErrorMessage)> GetBillType(Guid Id)
        {
            try
            {
                var result = await _billingTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                return result.Id.IsNullOrEmpty() ? (false, new BillingType(), "Bill Type Not Found") : (true, result, "Bill Type Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Bill Type",e.Message);
                return (false, new BillingType(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _billingTypeRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Error Deleting Bill Type");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _billingTypeRepository.Save();
                return (true, Id, "Bill Type deleted");

            }
            catch (Exception e)
            {
               Log.Error("Error Deleting Bill Type");
               return (false, Id, e.Message);
            }
        }
    }
}
