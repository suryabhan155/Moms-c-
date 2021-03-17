using System;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RegistrationManagement.Core.Domain.Facilities
{
    public interface IClinicRepository : IRepository<Clinic, Guid>
    {

    }
}
