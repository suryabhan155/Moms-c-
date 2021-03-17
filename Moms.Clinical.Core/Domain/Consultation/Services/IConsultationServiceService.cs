using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationServiceService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationService>, ResponseModel model)> LoadConsultationServices();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationService> consultations, ResponseModel model)> GetConsultationServices(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationService(Guid id);
        Task<(bool IsSuccess, Models.ConsultationService consultation, ResponseModel model)> AddConsultationService(Models.ConsultationService consultation);
    }
}
