using System;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class DeathDto
    {
        public Guid id { get; set; }
        public DateTime DateDeceased { get; set; }
        public Guid ReasonDeceased { get; set; }
        public Guid ICD10 { get; set; }
        public Guid PatientId { get; set; }
    }
}
