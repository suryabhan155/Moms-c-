using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Consultation.Services
{
    public interface IVitalsService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Vitals>, string ErrorMessage)> LoadVitals();
        Task<(bool IsSuccess, IEnumerable<Models.Vitals> vitalses, string ErrorMessage)> GetVitals(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteVitals(Guid id);
        Task<(bool IsSuccess, Models.Vitals vitals, string ErrorMEssage)> AddVitals(Models.Vitals vitals);
    }
}
