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
    public class BillingItemTypeService : IBillingItemTypeService
    {
        private readonly IBillingItemTypeRepository _billmasterRepository;

        public BillingItemTypeService(IBillingItemTypeRepository billmasterRepository)
        {
            _billmasterRepository = billmasterRepository;
        }

        public async Task<(bool IsSuccess, BillingItemType item, ResponseModel response)> CreateItem(BillingItemType itemMaster)
        {
            try
            {
                if (itemMaster.Id.IsNullOrEmpty())
                    _billmasterRepository.Create(itemMaster);
                else
                    _billmasterRepository.Update(itemMaster);
                await _billmasterRepository.Save();
                return (true, itemMaster, new ResponseModel { message = "Billing Type Saved", data = itemMaster, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Billing Type", e.Message);
                return (false, itemMaster, new ResponseModel { message = e.Message, data = itemMaster, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel response)> Delete(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id &&  x.Void == false).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Billing Item Type Does Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    if (result.Id.IsNullOrEmpty())
                        return (false, Id, new ResponseModel { message = "Error Deleting Bill Item Type", data = Id, code = HttpStatusCode.NotFound });
                    else
                    {
                        result.Void = true;
                        result.VoidDate = DateTime.Today;
                        _billmasterRepository.Update(result);
                        await _billmasterRepository.Save();
                        return (true, Id, new ResponseModel { message = "Bill Item Type deleted", data = Id, code = HttpStatusCode.OK });
                    }
                }

            }
            catch (Exception e)
            {
                Log.Error("Error Deleting Bill Item Type");
                return (false, Id, new ResponseModel { message = e.Message, data = Id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingItemType> billingItems, ResponseModel response)> GetAllBillingItem()
        {
            try
            {
                //var result = await _billmasterRepository.GetAll(x => x.Void == false).ToListAsync();
                var result = _billmasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                return result.Count > 0 ? (true, result, new ResponseModel { message = "Billing Item Type Loaded", data = result, code = HttpStatusCode.OK }) : (false, new List<BillingItemType>(), new ResponseModel { message = "Billing Item Type Not Found", data = new List<BillingItemType>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error loading Billing Item Type", e.Message);
                return (false, new List<BillingItemType>(), new ResponseModel { message = e.Message, data = new List<BillingItemType>(), code = HttpStatusCode.InternalServerError });
            }
        }

        

        public async Task<(bool IsSuccess, BillingItemType billingItem, ResponseModel response)> GetBillingItemById(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result == null)
                    return (false, new BillingItemType(), new ResponseModel { message = "Bill Item Type Not Found", data = result, code = HttpStatusCode.NotFound });
                else
                    return result.Id.IsNullOrEmpty() ? (false, new BillingItemType(), new ResponseModel { message = "Bill Item Type Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Bill Item Type Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Bill Item Type", e.Message);
                return (false, new BillingItemType(), new ResponseModel { message = e.Message, data = new BillingItemType(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
