using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface ILabOrderSampleResultService
    {

        Task<(bool IsSuccess, IEnumerable<LabOrderSampleResult>, string ErrorMessage)> LoadLabOrderSampleResult();
        Task<(bool IsSuccess, IEnumerable<LabOrderSampleResult> labOrderSampleResults, string ErrorMessage)> GetLabOrderSampleResult(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSampleResult(Guid id);
        Task<(bool IsSuccess, LabOrderSampleResult labOrderSampleResult, string ErrorMEssage)> AddLabOrderSampleResut(LabOrderSampleResult labOrderSampleResult);


    }
}
