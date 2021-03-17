using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Consultation>, ResponseModel model)> LoadConsultations();
        Task<(bool IsSuccess, IEnumerable<Models.Consultation> consultations, ResponseModel model)> GetConsultation(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultation(Guid id);
        Task<(bool IsSuccess, Models.Consultation consultation, ResponseModel model)> AddConsultation(Models.Consultation consultation);
    }
}
