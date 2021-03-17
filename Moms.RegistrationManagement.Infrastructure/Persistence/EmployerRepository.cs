using System;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class EmployerRepository:BaseRepository<Employer, Guid>, IEmployerRepository
    {
        public EmployerRepository(RegistrationContext context) : base(context)
        {
        }
    }
}
