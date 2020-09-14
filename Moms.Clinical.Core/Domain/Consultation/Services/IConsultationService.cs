using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IConsultationService
    {

        Task<(bool IsSuccess, IEnumerable<Models.Consultation>, string ErrorMessage)> LoadConsultations();
        Task<(bool IsSuccess, IEnumerable<Models.Consultation> labOrders, string ErrorMessage)> GetConsultation(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrder(Guid id);
        Task<(bool IsSuccess, LabOrder labOrder, string ErrorMEssage)> AddLabOrder(LabOrder labOrder);
    }
}
