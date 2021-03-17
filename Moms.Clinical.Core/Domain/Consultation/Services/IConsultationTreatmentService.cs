using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationTreatmentService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationTreatment>, ResponseModel model)> LoadConsultationTreatments();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationTreatment> consultations, ResponseModel model)> GetConsultationTreatments(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationTreatment(Guid id);
        Task<(bool IsSuccess, Models.ConsultationTreatment consultation, ResponseModel model)> AddConsultationTreatment(Models.ConsultationTreatment consultation);
    }
}
