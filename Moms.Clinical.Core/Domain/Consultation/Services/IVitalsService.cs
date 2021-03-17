using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IVitalsService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Vital> vitals, ResponseModel model)> LoadVitals();
        (bool IsSuccess, Models.Vital vital, ResponseModel model) GetVitals(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteVitals(Guid id);
        Task<(bool IsSuccess, Models.Vital vitals, ResponseModel model)> AddVitals(Models.Vital vitals);
        Task<(bool IsSuccess, IEnumerable<Models.Vital> vitals, ResponseModel model)> GetPatientVitals(Guid patientId);
    }
}
