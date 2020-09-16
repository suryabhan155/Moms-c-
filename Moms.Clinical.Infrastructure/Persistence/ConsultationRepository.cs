using System;
using System.Collections.Generic;
using System.Text;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Clinical.Infrastructure.Persistence
{
    public class ConsultationRepository : BaseRepository<Consultation, Guid>, IConsultationRepository
    {
        public ConsultationRepository(ClinicalContext context) : base(context)
        {

        }

    }
}
