using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class ConsultationComplaint : Entity<Guid>
    {
        public Guid ConsultationId { get; set; }
        public DateTime StartDate { get; set; }
        public String Complaint { get; set; }

        public Consultation Consultation { get; set; }
    }
}
