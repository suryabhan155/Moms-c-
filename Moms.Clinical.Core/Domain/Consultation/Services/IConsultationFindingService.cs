using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationFindingService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationFinding>, string ErrorMessage)> LoadConsultationFindings();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationFinding> consultations, string ErrorMessage)> GetConsultationFindings(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationFinding(Guid id);
        Task<(bool IsSuccess, Models.ConsultationFinding consultation, string ErrorMEssage)> AddConsultationFinding(Models.ConsultationFinding consultation);
    }
}
