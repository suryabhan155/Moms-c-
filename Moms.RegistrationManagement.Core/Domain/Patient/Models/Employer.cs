using System;
using System.Text.Json.Serialization;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Employer:Entity<Guid>
    {
        public string Occupation { get; set; }
        public string Employers { get; set; }
        public string EmployerAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public Guid PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
