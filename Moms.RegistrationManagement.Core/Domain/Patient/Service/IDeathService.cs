using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Service
{
    public interface IDeathService
    {
        Task<(bool IsSuccess, IEnumerable<DeathDto>, string ErrorMessage)> LoadDeaths();
        Task<(bool IsSuccess, IEnumerable<DeathDto> deathDtos, string ErrorMessage)> GetPatientDeath(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteDeath(Guid id);
        Task<(bool IsSuccess,Death death, string ErrorMEssage )> AddDeath(Death death);
    }
}
