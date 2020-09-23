using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class ConsultationTreatment : Entity<Guid>
    {
        public Guid ConsultationId { get; set; }
        public String Treatment { get; set; }
        public Consultation Consultation { get; set; }
    }
}
