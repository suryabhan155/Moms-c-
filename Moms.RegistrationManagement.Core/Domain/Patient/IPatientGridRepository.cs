using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RegistrationManagement.Core.Domain.Patient
{
    public interface IPatientGridRepository:IRepository<PatientGrid,Guid>
    {
        Task<(bool IsSuccess, IEnumerable<PatientGrid> patientGrids  , string ErrorMessage)> SearchPatient(string searchString);
        Task<(bool IsSuccess, IEnumerable<PatientGrid> patientGrids  , string ErrorMessage)> AllPatients();
    }
}
