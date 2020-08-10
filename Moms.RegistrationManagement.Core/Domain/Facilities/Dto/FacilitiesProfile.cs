using AutoMapper;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;

namespace Moms.RegistrationManagement.Core.Domain.Facilities.Dto
{
    public class FacilitiesProfile: Profile
    {
        public FacilitiesProfile()
        {
            CreateMap<Clinic, ClinicDto>();
        }
    }
}
