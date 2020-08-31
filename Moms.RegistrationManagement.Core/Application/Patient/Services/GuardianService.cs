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
    public class GuardianService: IGuardianService
    {
        private readonly IMapper _mapper;
        private readonly IGuardianRepository _guardianRepository;

        public GuardianService(IMapper mapper, IGuardianRepository guardianRepository)
        {
            _mapper = mapper;
            _guardianRepository = guardianRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<Guardian>, string ErrorMessage)> LoadGuardians()
        {
            try
            {
                var guardian = await _guardianRepository.GetAll().ToListAsync();
                return (true, _mapper.Map<List<Guardian>>(guardian), "guardians loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error loading guardian list");
                IEnumerable<Guardian> guardians = new List<Guardian>();
                return (false, guardians, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Guardian> guardians, string ErrorMessage)> GetPatientGuardians(Guid id)
        {
            try
            {
               IEnumerable<Guardian> _guardians=new List<Guardian>();
               if (id.IsNullOrEmpty())
                   return (false, _guardians, "patient Id is empty");

               var guardian = await _guardianRepository.GetAll(x => x.PatientId == id).ToListAsync();
               if (guardian == null)
                   return (false, _guardians, "No guardian information found");
               return (true, guardian, "patient guardian details found");
            }
            catch (Exception e)
            {
                Log.Error("Error loading guardian list");
                IEnumerable<Guardian> guardians = new List<Guardian>();
                return (false, guardians, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteGuardian(Guid id)
        {
            try
            {
                var guardian = await _guardianRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (guardian == null)
                    return (false, id, "unable to delete the guardian  info");
                _guardianRepository.Delete(guardian);
                return (true, id, $"$Guardian with id: {id} Deleted successfully");


            }
            catch (Exception e)
            {
                Log.Error("Error loading guardian");
                return (false, id, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Guardian guardian, string ErrorMEssage)> AddGuardian(Guardian guardian)
        {
            Guardian guardians = new Guardian();
            try
            {
                if (guardian == null)
                    return (false, guardians, "Empty payload submitted");
                if(guardians.PatientId.IsNullOrEmpty())
                    _guardianRepository.Create(guardian);
                _guardianRepository.Update(guardian);
                await _guardianRepository.Save();
                return (true, guardian, "Guardian added successfully");
            }
            catch (Exception e)
            {
               Log.Error("Error Adding Guardian information");
               return (false, guardians, $"{e.Message}");
            }
        }
    }
}
