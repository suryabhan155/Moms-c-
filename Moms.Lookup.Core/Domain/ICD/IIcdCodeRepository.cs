using System;
using System.Collections.Generic;
using System.Text;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Lookup.Core.Domain.ICD
{
    public interface IIcdCodeRepository : IRepository<IcdCode, Guid>
    {

    }
}
