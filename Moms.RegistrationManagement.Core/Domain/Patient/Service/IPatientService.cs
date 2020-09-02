using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Service
{
    public interface IPatientService
    {
        Task<(bool IsSuccess, IEnumerable<PatientDto>, string ErrorMessage)> LoadPatients();
        Task<(bool IsSuccess, Models.Patient patient, string ErrorMessage)> GetPatient(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeletePatient(Guid id);
        Task<(bool IsSuccess,Models.Patient patients, string ErrorMEssage )> AddPatient(Models.Patient patient);
    }
}