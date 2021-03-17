using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Service
{
    public interface IEmployeeService
    {
        Task<(bool IsSuccess, IEnumerable<EmployerDto>, string ErrorMessage)> LoadEmployees();
        Task<(bool IsSuccess, IEnumerable<EmployerDto> employerDtos, string ErrorMessage)> GetPatientEmployees(Guid patientId);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteEmployee(Guid id);
        Task<(bool IsSuccess,Employer  employer, string ErrorMEssage )> AddEmployer(Models.Patient patient);
    }
}
