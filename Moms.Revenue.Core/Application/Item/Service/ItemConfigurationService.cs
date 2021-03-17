using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;
using Moms.SharedKernel.Response;
using System.Net;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ItemConfigurationService:IItemConfigurationService
    {
        private readonly IITemConfigurationRepository _iTemConfigurationRepository;

        public ItemConfigurationService(IITemConfigurationRepository iTemConfigurationRepository)
        {
            _iTemConfigurationRepository = iTemConfigurationRepository;
        }

        public async Task<(bool IsSuccess, ItemConfiguration itemConfiguration, ResponseModel model)> Create(ItemConfiguration itemConfiguration)
        {
            try
            {
                if(itemConfiguration.Id.IsNullOrEmpty())
                    _iTemConfigurationRepository.Create(itemConfiguration);
                _iTemConfigurationRepository.Update(itemConfiguration);
                await _iTemConfigurationRepository.Save();
                return (true, itemConfiguration, new ResponseModel { message = "Item Configuration Saved", data = itemConfiguration , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, itemConfiguration, new ResponseModel { message = e.Message, data = itemConfiguration , code = HttpStatusCode.InternalServerError } );

            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemConfiguration> itemConfiguration, ResponseModel model)> GetAllConfiguration()
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMasters)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, new ResponseModel { message = "Item Configuration Loaded", data = result , code = HttpStatusCode.OK });
                return (false, new List<ItemConfiguration>(), new ResponseModel { message = "Not Found", data = new List<ItemConfiguration>(), code = HttpStatusCode.NotFound });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Configuration ",e.Message);
                return (false, new List<ItemConfiguration>(), new ResponseModel { message = e.Message, data = new List<ItemConfiguration>(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, ItemConfiguration itemConfiguration, ResponseModel model)> GetConfiguration(Guid Id)
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMasters)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, result, new ResponseModel { message = "Item Not Found", data = result , code = HttpStatusCode.NotFound } );
                return (true, result, new ResponseModel { message = "Item Configuration Loaded", data = result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, new ItemConfiguration(), new ResponseModel { message = e.Message, data = new ItemConfiguration(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, new ResponseModel { message = "Item Configuration Not Found", data = Id , code = HttpStatusCode.NotFound });
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _iTemConfigurationRepository.Save();
                return (true, Id, new ResponseModel { message = "Configuration Deleted", data = Id , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, Id, new ResponseModel { message = e.Message, data = Id , code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
