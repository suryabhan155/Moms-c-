using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface ILabOrderSampleService
    {

        Task<(bool IsSuccess, IEnumerable<LabOrderSample>, string ErrorMessage)> LoadLabOrderSamples();
        Task<(bool IsSuccess, IEnumerable<LabOrderSample> labOrderSamples, string ErrorMessage)> GetLabOrderSample(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSample(Guid id);
        Task<(bool IsSuccess, LabOrderSample labOrderSample, string ErrorMEssage)> AddLabOrderSample(LabOrderSample labOrderSample);


    }
}
