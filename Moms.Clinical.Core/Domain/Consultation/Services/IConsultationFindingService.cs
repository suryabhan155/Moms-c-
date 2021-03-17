using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationFindingService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationFinding>, ResponseModel model)> LoadConsultationFindings();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationFinding> consultations, ResponseModel model)> GetConsultationFindings(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationFinding(Guid id);
        Task<(bool IsSuccess, Models.ConsultationFinding consultation, ResponseModel model)> AddConsultationFinding(Models.ConsultationFinding consultation);
    }
}
