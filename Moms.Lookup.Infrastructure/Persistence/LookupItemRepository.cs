using System;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class LookupItemRepository:BaseRepository<LookupItem,Guid>, ILookupItemRepository
    {
        public LookupItemRepository(LookupContext context) : base(context)
        {
        }
    }
}
