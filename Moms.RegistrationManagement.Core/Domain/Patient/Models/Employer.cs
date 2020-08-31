using System;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Employer:Entity<Guid>
    {
        public string Occupation { get; set; }
        public string Employers { get; set; }
        public string EmployerAddress { get; set; }
        public Guid City { get; set; }
        public Guid Country { get; set; }
        public string Industry { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
