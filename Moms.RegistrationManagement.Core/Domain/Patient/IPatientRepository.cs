using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.SharedKernel.Interfaces.Persistence;
namespace Moms.RegistrationManagement.Core.Domain.Patient
{
    public interface IPatientRepository:IRepository<Models.Patient, Guid>
    {
        Task<(bool IsSuccess, IEnumerable<Models.Patient>  patients, string ErrorMessage)> SearchPatient(string searchString);
    }
}
