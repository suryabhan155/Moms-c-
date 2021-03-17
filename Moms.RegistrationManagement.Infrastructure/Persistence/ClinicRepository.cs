using System;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class ClinicRepository : BaseRepository<Clinic, Guid>, IClinicRepository
    {
        public ClinicRepository(RegistrationContext context) : base(context)
        {
        }
    }
}
