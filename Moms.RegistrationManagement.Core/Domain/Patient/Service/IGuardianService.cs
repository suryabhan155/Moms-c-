using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Service
{
    public interface IGuardianService
    {
        Task<(bool IsSuccess, IEnumerable<Guardian>, string ErrorMessage)> LoadGuardians();
        Task<(bool IsSuccess, IEnumerable<Guardian> guardians, string ErrorMessage)> GetPatientGuardians(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteGuardian(Guid id);
        Task<(bool IsSuccess,Guardian guardian, string ErrorMEssage )> AddGuardian(Guardian guardian);
    }
}
