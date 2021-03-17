using AutoMapper;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;

namespace Moms.RegistrationManagement.Core.Domain.Patient.Dto
{
    public class PatientProfile: Profile
    {
        public PatientProfile()
        {
            CreateMap<Models.Patient, PatientDto>();
            CreateMap<Death, DeathDto>();
            CreateMap<Employer, EmployerDto>();
            CreateMap<Guardian, GuardianDto>();
        }
    }
}
