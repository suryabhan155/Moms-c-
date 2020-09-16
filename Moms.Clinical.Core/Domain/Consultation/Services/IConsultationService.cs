using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Consultation>, string ErrorMessage)> LoadConsultations();
        Task<(bool IsSuccess, IEnumerable<Models.Consultation> consultations, string ErrorMessage)> GetConsultation(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultation(Guid id);
        Task<(bool IsSuccess, Models.Consultation consultation, string ErrorMEssage)> AddConsultation(Models.Consultation consultation);
    }
}
