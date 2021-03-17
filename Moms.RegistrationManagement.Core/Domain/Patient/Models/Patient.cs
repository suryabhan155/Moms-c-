using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;
using System.Text.Json.Serialization;
using NpgsqlTypes;


namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class Patient:Entity<Guid>
    {
        public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
       public DateTime DoB { get; set; }
       public Guid Sex { get; set; }
       public Guid MaritalStatus { get; set; }
       public string Narrative { get; set; }
       public string PatientNumber { get; set; }
       public string Phone { get; set; }
       public string IdentificationNumber { get; set; }
       public DateTime RegistrationDate { get; set; }

       [JsonIgnore]
       public NpgsqlTsVector SearchVector { get; set; }
       public ICollection<Guardian> Guardians { get; set; }=new List<Guardian>();
       public Death Death { get; set; }
       public ICollection<Contact> Contacts { get; set; }=new List<Contact>();
       public ICollection<Employer> Employers { get; set; }=new List<Employer>();
       public ICollection<LookupItem> LookupItems { get; set; }

    }
}
