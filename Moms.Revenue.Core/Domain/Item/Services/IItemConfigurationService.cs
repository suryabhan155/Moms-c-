using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Domain.Item.Services
{
    public interface IItemConfigurationService
    {
        Task<(bool IsSuccess, ItemConfiguration itemConfiguration , ResponseModel model)> Create(ItemConfiguration itemConfiguration);
        Task<(bool IsSuccess, IEnumerable<ItemConfiguration> itemConfiguration, ResponseModel model)> GetAllConfiguration();
        Task<(bool IsSuccess, ItemConfiguration itemConfiguration , ResponseModel model)> GetConfiguration(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
