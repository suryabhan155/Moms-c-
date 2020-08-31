using System;
using Moms.SharedKernel.Model;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Contact:Entity<Guid>
    {
       public string Address { get; set; }
       public Guid City { get; set; }
       public string PostalCode { get; set; }
       public Guid County { get; set; }
       public Guid SubCounty { get; set; }
       public string HomePhone { get; set; }
       public string MobilePhone { get; set; }
       public string Email { get; set; }
       public Guid PatientId { get; set; }
       public Patient Patient { get; set; }
    }
}
