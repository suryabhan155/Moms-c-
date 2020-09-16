using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Dto;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.RegistrationManagement.Core.Application.Patient.Services
{
    public class PatientService:IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }


        public async Task<(bool IsSuccess, IEnumerable<PatientDto> patients, string ErrorMessage)> LoadPatients()
        {
            try
            {
                var patients = await _patientRepository.GetAll(x=>!x.Void).ToListAsync();
                return (true,_mapper.Map<List<PatientDto>>(patients),"Patient Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("patient Load: Error occured",e);
               IEnumerable<PatientDto>  patientDto=new List<PatientDto>();
               return (false, patientDto, e.Message);
            }
        }

        public async Task<(bool IsSuccess, Domain.Patient.Models.Patient patient, string ErrorMessage)> GetPatient(Guid id)
        {
            try
            {
                var patient = await _patientRepository.GetAll(x => x.Id==id).FirstOrDefaultAsync();
                return (true, patient, "Patient Loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading a patient");
                Domain.Patient.Models.Patient patient=new Domain.Patient.Models.Patient();
                return (false, patient, e.Message);

            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeletePatient(Guid id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    return (false, id, "No Id provided");
                _patientRepository.DeleteById(id);
                await _patientRepository.Save();
                return (true, id, "Patient deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error($"Error deleting patient with Id: {id}");
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Domain.Patient.Models.Patient patients, string ErrorMEssage)> AddPatient(Domain.Patient.Models.Patient patient)
        {
            try
            {
                Guid id = patient.Id;
                if(id.IsNullOrEmpty())
                    _patientRepository.Create(patient);
                _patientRepository.Update(patient);
                await _patientRepository.Save();
                return (true, patient, "Patient Added successfully");
            }
            catch (Exception e)
            {
                Log.Error($"Error deleting patient with Id");
                Domain.Patient.Models.Patient patients=new Domain.Patient.Models.Patient();
                return (false, patients, $"{e.Message}");
            }
        }
    }
}
