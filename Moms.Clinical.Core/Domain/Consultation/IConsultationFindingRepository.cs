using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Clinical.Core.Domain.Consultation
{
    public interface IConsultationFindingRepository : IRepository<Models.ConsultationFinding, Guid>
    {

    }
}
