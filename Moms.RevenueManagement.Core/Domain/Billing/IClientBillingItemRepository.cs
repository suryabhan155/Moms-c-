using System;
using Moms.RevenueManagement.Core.Domain.Billing.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RevenueManagement.Core.Domain.Billing
{
    public interface IClientBillingItemRepository:IRepository<ClientBillingItem, Guid>
    {

    }
}
