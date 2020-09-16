using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationServiceService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationService>, string ErrorMessage)> LoadConsultationServices();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationService> consultations, string ErrorMessage)> GetConsultationServices(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationService(Guid id);
        Task<(bool IsSuccess, Models.ConsultationService consultation, string ErrorMEssage)> AddConsultationService(Models.ConsultationService consultation);
    }
}
