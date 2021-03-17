using System;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Revenue.Core.Domain.Billing
{
    public interface IClientBillRepository:IRepository<ClientBill, Guid>
    {

    }
}
