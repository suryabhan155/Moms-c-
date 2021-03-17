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
    public class BillingItemConfigurationService : IBillingItemConfigurationService
    {
        private readonly IBillingItemConfigurationRepository _billconfigurationRepository;

        public BillingItemConfigurationService(IBillingItemConfigurationRepository billconfigurationRepository)
        {
            _billconfigurationRepository = billconfigurationRepository;
        }

        public async Task<(bool IsSuccess, BillingItemConfiguration itemConfiguration, ResponseModel model)> Create(BillingItemConfiguration itemConfiguration)
        {
            try
            {
                if (itemConfiguration.Id.IsNullOrEmpty())
                    _billconfigurationRepository.Create(itemConfiguration);
                else
                    _billconfigurationRepository.Update(itemConfiguration);
                await _billconfigurationRepository.Save();
                return (true, itemConfiguration, new ResponseModel { message = "Item Configuration Saved", data = itemConfiguration, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ", e.Message);
                return (false, itemConfiguration, new ResponseModel { message = e.Message, data = itemConfiguration, code = HttpStatusCode.InternalServerError });

            }
        }

        public async Task<(bool IsSuccess, IEnumerable<BillingItemConfiguration> itemConfiguration, ResponseModel model)> GetAllConfiguration()
        {
            try
            {
                var result = _billconfigurationRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC).ToList();
                    //.Include(x => x.BillingItemMasters)
                    //.ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Item Configuration Loaded", data = result, code = HttpStatusCode.OK });
                else
                    return (false, new List<BillingItemConfiguration>(), new ResponseModel { message = "Item Configuration Not Found", data = result, code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Configuration ", e.Message);
                return (false, new List<BillingItemConfiguration>(), new ResponseModel { message = e.Message, data = new List<BillingItemConfiguration>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, BillingItemConfiguration itemConfiguration, ResponseModel model)> GetConfiguration(Guid Id)
        {
            try
            {
                var result = await _billconfigurationRepository.GetAll()
                    .Include(x => x.BillingItemMasters)
                    .FirstOrDefaultAsync();
                if (result == null)
                    return (false, result, new ResponseModel { message = "Item Configuration Not Found", data = result, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, result, new ResponseModel { message = "Item Configuration Not Found", data = result, code = HttpStatusCode.NotFound });
                else
                    return (true, result, new ResponseModel { message = "Item Configuration Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ", e.Message);
                return (false, new BillingItemConfiguration(), new ResponseModel { message = e.Message, data = new BillingItemConfiguration(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _billconfigurationRepository.GetAll(x => x.Id == Id && x.Void == false).FirstOrDefaultAsync();
                if(result == null)
                    return (false, Id, new ResponseModel { message = "Item Configuration Not Found", data = Id, code = HttpStatusCode.NotFound });
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Item Configuration Not Found", data = Id, code = HttpStatusCode.NotFound });
                else
                {
                    result.Void = true;
                    result.VoidDate = DateTime.Today;
                    _billconfigurationRepository.Update(result);
                    await _billconfigurationRepository.Save();
                    return (true, Id, new ResponseModel { message = "Configuration Deleted", data = Id, code = HttpStatusCode.OK });
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ", e.Message);
                return (false, Id, new ResponseModel { message = e.Message, data = Id, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
