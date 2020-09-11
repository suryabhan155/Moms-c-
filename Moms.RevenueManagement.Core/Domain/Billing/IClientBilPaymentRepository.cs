using System;
using Moms.RevenueManagement.Core.Domain.Billing.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RevenueManagement.Core.Domain.Billing
{
    public interface IClientBilPaymentRepository:IRepository<ClientBillPayment, Guid>
    {

    }
}
