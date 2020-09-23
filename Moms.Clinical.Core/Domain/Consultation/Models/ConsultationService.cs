
using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class ConsultationService : Entity<Guid>
    {
        public Guid ConsultationId { get; set; }
        public Guid ItemId { get; set; }
        public Double Quantity { get; set; }
        public String Description { get; set; }
        public Consultation Consultation { get; set; }
    }
}
