using System;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class GuardianDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid Relationship { get; set; }
    }
}
