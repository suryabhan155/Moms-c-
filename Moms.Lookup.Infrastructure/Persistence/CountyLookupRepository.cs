using System;
using Moms.Lookup.Core.Domain.Options;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Lookup.Infrastructure.Persistence
{
    public class CountyLookupRepository:BaseRepository<CountyLookup,Guid>,ICountyLookupRepository
    {
        public CountyLookupRepository(LookupContext context):base(context)
        {

        }
    }
}
