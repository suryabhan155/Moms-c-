using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Clinical.Core.Domain.Consultation
{
    public interface IConsultationRepository : IRepository<Models.Consultation, Guid>
    {

    }
}
