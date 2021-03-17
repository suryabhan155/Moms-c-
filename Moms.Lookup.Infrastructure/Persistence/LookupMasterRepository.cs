using System;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupMasterRepository:BaseRepository<LookupMaster, Guid>, ILookupMasterRepository
    {
        public LookupMasterRepository(LookupContext context) : base(context)
        {

        }
    }
}
