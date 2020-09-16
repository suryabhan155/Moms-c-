using System;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain
{
    public interface ILookupMasterRepository: IRepository<LookupMaster, Guid>
    {

    }
}
