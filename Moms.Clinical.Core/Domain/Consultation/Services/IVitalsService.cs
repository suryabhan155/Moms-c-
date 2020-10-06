using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IVitalsService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Vital> vitals, string ErrorMessage)> LoadVitals();
        (bool IsSuccess, Models.Vital vital, string ErrorMessage) GetVitals(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteVitals(Guid id);
        Task<(bool IsSuccess, Models.Vital vitals, string ErrorMEssage)> AddVitals(Models.Vital vitals);
        Task<(bool IsSuccess, IEnumerable<Models.Vital> vitals, string ErrorMEssage)> GetPatientVitals(Guid patientId);
    }
}
