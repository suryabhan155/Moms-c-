using System;
using System.Text.Json.Serialization;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Death:Entity<Guid>
    {
       public DateTime DateDeceased { get; set; }
       public Guid ReasonDeceased { get; set; }
       public Guid ICD10 { get; set; }
       public Guid PatientId { get; set; }
       [JsonIgnore]
       public Patient Patient { get; set; }
    }
}
