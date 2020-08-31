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
        Task<(bool IsSuccess, DeathDto, string ErrorMessage)> GetDeath(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteDeath(Guid id);
        Task<(bool IsSuccess,Models.Patient patients, string ErrorMEssage )> AddDeath(Death death);
    }
}
