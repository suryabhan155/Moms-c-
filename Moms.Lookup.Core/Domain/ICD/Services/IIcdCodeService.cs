using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.Lookup.Core.Domain.ICD.Models;

namespace Moms.Lookup.Core.Domain.ICD.Services
{
    public interface IIcdCodeService
    {
        Task<(bool IsSuccess, IEnumerable<IcdCode> icdCode, string ErrorMessage)> SearchDiagnosis(String icdCode);
    }
}
