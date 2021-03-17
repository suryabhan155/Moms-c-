using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationDiagnosisService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationDiagnosis>, ResponseModel model)> LoadConsultationDiagnosis();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationDiagnosis> consultations, ResponseModel model)> GetConsultationDiagnosis(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationDiagnosis(Guid id);
        Task<(bool IsSuccess, Models.ConsultationDiagnosis consultation, ResponseModel model)> AddConsultationDiagnosis(Models.ConsultationDiagnosis consultation);
    }
}
