using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Revenue.Core.Domain.Item;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.Revenue.Core.Domain.Item.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Revenue.Core.Application.Item.Service
{
    public class ItemConfigurationService:IItemConfigurationService
    {
        private readonly IITemConfigurationRepository _iTemConfigurationRepository;

        public ItemConfigurationService(IITemConfigurationRepository iTemConfigurationRepository)
        {
            _iTemConfigurationRepository = iTemConfigurationRepository;
        }

        public async Task<(bool IsSuccess, ItemConfiguration itemConfiguration, string ErrorMessage)> Create(ItemConfiguration itemConfiguration)
        {
            try
            {
                if(itemConfiguration.Id.IsNullOrEmpty())
                    _iTemConfigurationRepository.Create(itemConfiguration);
                _iTemConfigurationRepository.Update(itemConfiguration);
                await _iTemConfigurationRepository.Save();
                return (true, itemConfiguration, "Item Configuration Saved");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, itemConfiguration, e.Message);

            }
        }

        public async Task<(bool IsSuccess, IEnumerable<ItemConfiguration> itemConfiguration, string ErrorMessage)> GetAllConfiguration()
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMasters)
                    .ToListAsync();
                if (result.Count > 0)
                    return (true, result, "Item Configuration Loaded");
                return (false, new List<ItemConfiguration>(), "Not Found");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Configuration ",e.Message);
                return (false, new List<ItemConfiguration>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, ItemConfiguration itemConfiguration, string ErrorMessage)> GetConfiguration(Guid Id)
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => !x.Void)
                    .Include(x => x.ItemMasters)
                    .FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, result, "Item Not Found");
                return (true, result, "Item Configuration Loade");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, new ItemConfiguration(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id)
        {
            try
            {
                var result = await _iTemConfigurationRepository.GetAll(x => x.Id == Id).FirstOrDefaultAsync();
                if (result.Id.IsNullOrEmpty())
                    return (false, Id, "Item Configuration Not Found");
                result.Void = true;
                result.VoidDate=DateTime.Today;
                await _iTemConfigurationRepository.Save();
                return (true, Id, "Configuration Deleted");
            }
            catch (Exception e)
            {
                Log.Error("Error Saving Configuration ",e.Message);
                return (false, Id, e.Message);
            }
        }
    }
}
