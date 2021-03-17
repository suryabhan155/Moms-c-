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
using Moms.SharedKernel.Response;
using System.Net;
using Moms.SharedKernel.Interfaces.Persistence;
using System.Linq;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class BillingMasterService : IBillingMasterService
    {// it is billingtype 
        private readonly IBillingMasterRepository _billmasterRepository;

        public BillingMasterService(IBillingMasterRepository billmasterRepository)
        {
            _billmasterRepository = billmasterRepository;
        }

        public async Task<(bool IsSuccess, BillingMaster billingmaster, ResponseModel model)> Create(BillingMaster billingType)
        {
            try
            {
                if (billingType.Id.IsNullOrEmpty())
                    _billmasterRepository.Create(billingType);
                else
                    _billmasterRepository.Update(billingType);
                await _billmasterRepository.Save();
                return (true, billingType, new ResponseModel { message = "Billing Type Saved", data = billingType, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Billing Type", e.Message);
                return (false, billingType, new ResponseModel { message = e.Message, data = billingType, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Billing Discount Item Does Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    if (result.Id.IsNullOrEmpty())
                        return (false, Id, new ResponseModel { message = "Error Deleting Bill Type", data = Id, code = HttpStatusCode.NotFound });
                    else
                    {
                        result.Void = true;
                        result.VoidDate = DateTime.Today;
                        _billmasterRepository.Update(result);
                        await _billmasterRepository.Save();
                        return (true, Id, new ResponseModel { message = "Bill Type deleted", data = Id, code = HttpStatusCode.OK });
                    }
                }
            }
            catch (Exception e)
            {
               Log.Error("Error Deleting Bill Type");
               return (false, Id, new ResponseModel { message = e.Message, data = Id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingMaster> billingmaster, ResponseModel model)> GetAllBillingType()
        {
            try
            {
                var result = _billmasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                //var result = await _billmasterRepository.GetAll(x => x.Void == false).ToListAsync();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Billing Loaded", data = result, code = HttpStatusCode.OK }) : (false, new List<BillingMaster>(), new ResponseModel { message = "Billing Types Not Found", data = new List<BillingMaster>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error loading Billing Type", e.Message);
                return (false, new List<BillingMaster>(), new ResponseModel { message = e.Message, data = new List<BillingMaster>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, BillingMaster billingmaster, ResponseModel model)> GetBillType(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id ).FirstOrDefaultAsync();
                if (result == null)
                    return (false, new BillingMaster(), new ResponseModel { message = "Bill Type Not Found", data =result, code = HttpStatusCode.NotFound });
                else
                    return result.Id.IsNullOrEmpty() ? (false, new BillingMaster(), new ResponseModel { message = "Bill Type Not Found", data =  result, code = HttpStatusCode.NotFound } ) : (true, result, new ResponseModel { message = "Bill Type Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Bill Type", e.Message);
                return (false, new BillingMaster(), new ResponseModel { message = e.Message, data = new BillingMaster(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
