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
    public class BillingItemMasterService : IBillingItemMasterService
    {
        private readonly IBillingItemMasterRepository _billmasterRepository;

        public BillingItemMasterService(IBillingItemMasterRepository billmasterRepository)
        {
            _billmasterRepository = billmasterRepository;
        }

        public async Task<(bool IsSuccess, BillingItemMaster itemMaster, ResponseModel model)> Create(BillingItemMaster itemMaster)
        {
            try
            {
                if (itemMaster.Id.IsNullOrEmpty())
                    _billmasterRepository.Create(itemMaster);
                else
                    _billmasterRepository.Update(itemMaster);
                await _billmasterRepository.Save();
                return (true, itemMaster, new ResponseModel { message = "Item Master Saved", data = itemMaster, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in saving Item Master", e.Message);
                return (false, new BillingItemMaster(), new ResponseModel { message = e.Message, data = new BillingItemMaster(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingItemMaster> itemMaster, ResponseModel model)> GetAllItemMaster()
        {
            try
            {
                var result = _billmasterRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC)
                    //.Include(x => x.ItemType)
                    //.Include(x => x.ItemTypeSubType)
                    .ToList();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Item Master Loaded", data = result, code = HttpStatusCode.OK });
                else
                    return (false, new List<BillingItemMaster>(), new ResponseModel { message = "Item Master Not Found", data = new List<BillingItemMaster>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master", e.Message);
                return (false, new List<BillingItemMaster>(), new ResponseModel { message = e.Message, data = new List<BillingItemMaster>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, BillingItemMaster itemMaster, ResponseModel model)> GetItemMaster(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id)
                    //.Include(x => x.ItemType)
                    //.Include(x => x.ItemTypeSubType)
                    .FirstOrDefaultAsync();
                if (result == null)
                    return (false, new BillingItemMaster(), new ResponseModel { message = "Item Master Not Found", data = result, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, new BillingItemMaster(), new ResponseModel { message = "Item Master Not Found", data = result, code = HttpStatusCode.NotFound });
                else
                    return (true, result, new ResponseModel { message = "Item Master Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master", e.Message);
                return (false, new BillingItemMaster(), new ResponseModel { message = e.Message, data = new BillingItemMaster(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _billmasterRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if (result == null)
                    return (false, Id, new ResponseModel { message = "Item Master Not Found", data = Id, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Item Master Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    result.Void = true;
                    result.VoidDate = DateTime.Today;
                    _billmasterRepository.Update(result);
                    await _billmasterRepository.Save();
                    return (true, Id, new ResponseModel { message = "Item Master Delete", data = Id, code = HttpStatusCode.OK });
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in Loading Item Master", e.Message);
                return (false, Id, new ResponseModel { message = e.Message, data = Id, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
