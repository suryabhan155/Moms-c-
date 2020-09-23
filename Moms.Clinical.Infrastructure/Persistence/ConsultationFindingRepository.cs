using System;
using System.Collections.Generic;
using System.Text;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Clinical.Infrastructure.Persistence
{
    public class ConsultationFindingRepository : BaseRepository<ConsultationFinding, Guid>, IConsultationFindingRepository
    {
        public ConsultationFindingRepository(ClinicalContext context) : base(context)
        {

        }

    }
}
