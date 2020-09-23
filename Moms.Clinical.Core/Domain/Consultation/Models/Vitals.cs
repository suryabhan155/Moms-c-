
using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class Vitals : Entity<Guid>
    {
        public Guid PatientId { get; set; }
        public DateTime VitalDateTime { get; set; }

        public Decimal Temperature { get; set; }
        public Decimal Weight { get; set; }
        public Decimal Height { get; set; }
        public Decimal BPDiastolic { get; set; }
        public Decimal BPSystolic { get; set; }
        public Decimal Pulse { get; set; }
        public Decimal RespiratoryRate { get; set; }
    }
}
