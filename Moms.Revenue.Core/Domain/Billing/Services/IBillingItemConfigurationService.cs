using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingItemConfigurationService
    {
        Task<(bool IsSuccess, BillingItemConfiguration itemConfiguration, ResponseModel model)> Create(BillingItemConfiguration itemConfiguration);
        Task<(bool IsSuccess, IEnumerable<BillingItemConfiguration> itemConfiguration, ResponseModel model)> GetAllConfiguration();
        Task<(bool IsSuccess, BillingItemConfiguration itemConfiguration, ResponseModel model)> GetConfiguration(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
