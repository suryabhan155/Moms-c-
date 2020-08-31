using System;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class EmployerDto
    {
        public Guid Id { get; set; }
        public string Occupation { get; set; }
        public string Employers { get; set; }
        public string EmployerAddress { get; set; }
        public Guid City { get; set; }
        public Guid Country { get; set; }
        public string Industry { get; set; }
    }
}
