using System;
using Moms.SharedKernel.Interfaces.Persistence;
namespace Moms.RegistrationManagement.Core.Domain.Patient
{
    public interface IPatientRepository:IRepository<Models.Patient, Guid>
    {

    }
}
