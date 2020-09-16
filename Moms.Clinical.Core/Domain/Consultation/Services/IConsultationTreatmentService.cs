using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationTreatmentService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationTreatment>, string ErrorMessage)> LoadConsultationTreatments();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationTreatment> consultations, string ErrorMessage)> GetConsultationTreatments(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationTreatment(Guid id);
        Task<(bool IsSuccess, Models.ConsultationTreatment consultation, string ErrorMEssage)> AddConsultationTreatment(Models.ConsultationTreatment consultation);
    }
}
