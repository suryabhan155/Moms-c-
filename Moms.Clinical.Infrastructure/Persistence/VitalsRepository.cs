using System;
using System.Collections.Generic;
using System.Text;
using Moms.Clinical.Core.Domain.Consultation;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Clinical.Infrastructure.Persistence
{
    public class VitalsRepository : BaseRepository<Vital, Guid>, IVitalsRepository
    {
        public VitalsRepository(ClinicalContext context) : base(context)
        {

        }

    }
}
