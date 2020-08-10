using System;
using System.Collections.Generic;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;

namespace Moms.RegistrationManagement.Core.Domain.Facilities
{
    public interface IClinicService
    {
        IEnumerable<ClinicDto> Load();
        void Register(Clinic clinic);
        void RemoveClinic(Guid id);
    }
}
