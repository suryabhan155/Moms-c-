using System;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.RegistrationManagement.Core.Domain.Patient
{
    public interface IContactRepository:IRepository<Contact, Guid>
    {

    }
}
