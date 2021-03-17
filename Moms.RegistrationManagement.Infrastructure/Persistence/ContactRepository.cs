using System;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class ContactRepository: BaseRepository<Contact, Guid>, IContactRepository
    {
        public ContactRepository(RegistrationContext context) : base(context)
        {
        }
    }
}
