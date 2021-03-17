using System;
using System.Data.Common;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid City { get; set; }
        public string PostalCode { get; set; }
        public Guid County { get; set; }
        public Guid SubCounty { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
