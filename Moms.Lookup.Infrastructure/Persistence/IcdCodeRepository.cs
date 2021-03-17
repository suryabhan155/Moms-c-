using System;
using Moms.Lookup.Core.Domain.ICD;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class IcdCodeRepository : BaseRepository<IcdCode, Guid>, IIcdCodeRepository
    {
        public IcdCodeRepository(LookupContext context) : base(context)
        {
        }
    }
}
