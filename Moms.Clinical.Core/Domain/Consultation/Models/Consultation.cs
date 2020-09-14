using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Clinical.Core.Domain.Consultation.Models
{
    public class Consultation : Entity<Guid>
    {
        public Guid PatientId { get; set; }
        public DateTime ConsultationDate { get; set; }
        public Boolean ConsultationType { get; set; }
        public String Details { get; set; }
        public String Recommendations { get; set; }

        public ICollection<ConsultationComplaint> ConsultationComplaints { get; set; } = new List<ConsultationComplaint>();
        public ICollection<ConsultationFinding> ConsultationFindings { get; set; } = new List<ConsultationFinding>();
        public ICollection<ConsultationDiagnosis> ConsultationDiagnosis { get; set; } = new List<ConsultationDiagnosis>();
        public ICollection<ConsultationTreatment> ConsultationTreatments { get; set; } = new List<ConsultationTreatment>();
        public ICollection<ConsultationService> ConsultationServices { get; set; } = new List<ConsultationService>();
    }
}
