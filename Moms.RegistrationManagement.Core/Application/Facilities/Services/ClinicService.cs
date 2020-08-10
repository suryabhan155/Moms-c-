using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Facilities.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IMapper mapper, IClinicRepository clinicRepository)
        {
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }

        public IEnumerable<ClinicDto> Load()
        {
            try
            {
                var clinics = _clinicRepository.GetAll().ToList();
                return _mapper.Map<List<ClinicDto>>(clinics);
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                throw new Exception($"Error loading records ! {e.Message}");
            }
        }

        public void Register(Clinic clinic)
        {
            if (!clinic.IsValid())
                throw new Exception("Clinic is invalid!");

            try
            {
                _clinicRepository.Create(clinic);
                _clinicRepository.Save();
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                throw new Exception($"Error saving record ! {e.Message}");
            }
        }

        public void RemoveClinic(Guid id)
        {
            try
            {
                _clinicRepository.DeleteById(id);
                _clinicRepository.Save();
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                throw new Exception($"Error deleting record ! {e.Message}");
            }
        }
    }
}
