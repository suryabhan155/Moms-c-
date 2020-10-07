using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemConfigurationService
    {
        Task<(bool IsSuccess, ItemConfiguration itemConfiguration , string ErrorMessage)> Create(ItemConfiguration itemConfiguration);
        Task<(bool IsSuccess, IEnumerable<ItemConfiguration> itemConfiguration, string ErrorMessage)> GetAllConfiguration();
        Task<(bool IsSuccess, ItemConfiguration itemConfiguration , string ErrorMessage)> GetConfiguration(Guid Id);
        Task<(bool IsSuccess, Guid Id, string ErrorMEssage)> Delete(Guid Id);
    }
}
