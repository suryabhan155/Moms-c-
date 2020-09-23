using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class ConsultationFinding : Entity<Guid>
    {
        public Guid ConsultationId { get; set; }
        public String Finding { get; set; }
        public Consultation Consultation { get; set; }
    }
}
