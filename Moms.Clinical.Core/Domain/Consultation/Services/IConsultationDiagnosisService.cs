using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationDiagnosisService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationDiagnosis>, string ErrorMessage)> LoadConsultationDiagnosis();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationDiagnosis> consultations, string ErrorMessage)> GetConsultationDiagnosis(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationDiagnosis(Guid id);
        Task<(bool IsSuccess, Models.ConsultationDiagnosis consultation, string ErrorMEssage)> AddConsultationDiagnosis(Models.ConsultationDiagnosis consultation);
    }
}
