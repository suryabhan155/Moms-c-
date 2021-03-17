using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class ConsultationDiagnosis : Entity<Guid>
    {
        public Guid ConsultationId { get; set; }
        public Guid Diagnosis { get; set; }
        public Consultation Consultation { get; set; }
    }
}
