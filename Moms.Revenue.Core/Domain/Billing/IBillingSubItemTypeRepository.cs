using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Revenue.Core.Domain.Billing
{
    public interface IBillingSubItemTypeRepository : IRepository<BillingSubItemType, Guid>
    {
    }
}
