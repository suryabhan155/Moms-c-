using System;
using Moms.RevenueManagement.Core.Domain.Item.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RevenueManagement.Core.Domain.Item
{
    public interface IITemTypeSubTypeRepository: IRepository<ItemTypeSubType, Guid>
    {

    }
}