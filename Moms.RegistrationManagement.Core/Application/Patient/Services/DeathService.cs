using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Patient.Services
{
    public class DeathService: IDeathService
    {
        private readonly IMapper _mapper;
        private readonly IDeathRepository _deathRepository;

        public DeathService(IMapper mapper, IDeathRepository deathRepository)
        {
            _mapper = mapper;
            _deathRepository = deathRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<DeathDto>, string ErrorMessage)> LoadDeaths()
        {
            IEnumerable<DeathDto> deathDtos=new List<DeathDto>();
            try
            {
                var death = await _deathRepository.GetAll().ToListAsync();
                if (death == null)
                    return (false, deathDtos, "No records found");
                return (true, _mapper.Map<List<DeathDto>>(death), "death data loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error loading patient data");
                return(false,deathDtos,$"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<DeathDto> deathDtos, string ErrorMessage)> GetPatientDeath(Guid id)
        {
            IEnumerable<DeathDto> deathDtos = new List<DeathDto>();
            try
            {
                var death = await _deathRepository.GetAll(x => x.PatientId == id).ToListAsync();
                if (death == null)
                    return (false, deathDtos, "Patient death Status NOT found");
                return (true,_mapper.Map<List<DeathDto>>(death) , "Patient Deaths Status found");
            }
            catch (Exception e)
            {
                Log.Error("Error loading patient Death Status");
                return(false,deathDtos,$"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteDeath(Guid id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    return (true, id, "No Delete Id provided");
                _deathRepository.DeleteById(id);
                await _deathRepository.Save();
                return (true, id, $"Death Status deleted successfully{id}");
            }
            catch (Exception e)
            {
               Log.Error("Error deleting patient death Status");
               return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Death death, string ErrorMEssage)> AddDeath(Death death)
        {
            Death deaths=new Death();
            try
            {
                if (death == null)
                    return (false, null, "empty payload found");
                if(death.PatientId.IsNullOrEmpty())
                    _deathRepository.Create(death);
                _deathRepository.Update(death);
                await _deathRepository.Save();
                return (true, death, "Death Status SET successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
