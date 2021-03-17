using System;
using Moms.SharedKernel.Model;
using NpgsqlTypes;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Models
{
    public class PatientGrid:Entity<Guid>
    {
       // public Guid Id { get; set; }
       public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
       public DateTime DoB { get; set; }
       public Guid SexId { get; set; }
       public string Sex { get; set; }
       public Guid MaritalStatusId { get; set; }
       public string MaritalStatus { get; set; }
       public string Narrative { get; set; }
     //  public DateTime CreateDate { get; set; }
      // public Boolean Void { get; set; }
      // public DateTime VoidDate { get; set; }
      // public Guid UserId { get; set; }
       public NpgsqlTsVector SearchVector { get; set; }
       public string IdentificationNumber { get; set; }
       public string PatientNumber { get; set; }
       public string Phone { get; set; }
       public DateTime RegistrationDate { get; set; }
    }
}
