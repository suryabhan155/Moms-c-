using System;
using System.Text.Json.Serialization;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Guardian: Entity<Guid>
    {
        public Guid PatientId { get; set; }
        public Guid Relationship { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
