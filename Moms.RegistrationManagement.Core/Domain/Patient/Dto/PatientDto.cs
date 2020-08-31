using System;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public Guid Sex { get; set; }
        public Guid MaritalStatus { get; set; }
        public string Narrative { get; set; }
    }
}
