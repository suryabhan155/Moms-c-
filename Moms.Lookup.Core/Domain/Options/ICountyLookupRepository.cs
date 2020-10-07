using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain.Options
{
    public interface ICountyLookupRepository:IRepository<CountyLookup, Guid>
    {
        Task<(bool IsSuccess, IEnumerable<CountyLookup>  countyLookups, string ErrorMessage)> SearchPatient(string searchString);
    }
}
