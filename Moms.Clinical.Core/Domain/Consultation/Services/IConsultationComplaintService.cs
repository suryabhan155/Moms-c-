using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationComplaintService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationComplaint>, string ErrorMessage)> LoadConsultationComplaints();
        Task<(bool IsSuccess, IEnumerable<Models.ConsultationComplaint> consultations, string ErrorMessage)> GetConsultationComplaint(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteConsultationComplaint(Guid id);
        Task<(bool IsSuccess, Models.ConsultationComplaint consultation, string ErrorMEssage)> AddConsultationComplaint(Models.ConsultationComplaint consultation);
    }
}
