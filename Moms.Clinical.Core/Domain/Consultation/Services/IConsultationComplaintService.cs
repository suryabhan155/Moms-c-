using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationComplaintService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationComplaint>, ResponseModel model)> LoadConsultationComplaints();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationComplaint> consultations, ResponseModel model)> GetConsultationComplaint(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteConsultationComplaint(Guid id);
        Task<(bool IsSuccess, Models.ConsultationComplaint consultation, ResponseModel model)> AddConsultationComplaint(Models.ConsultationComplaint consultation);
    }
}
