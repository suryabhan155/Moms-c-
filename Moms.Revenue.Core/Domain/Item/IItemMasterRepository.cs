using System;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Revenue.Core.Domain.Item
{
    public interface IItemMasterRepository:IRepository<ItemMaster, Guid>
    {

    }
}
