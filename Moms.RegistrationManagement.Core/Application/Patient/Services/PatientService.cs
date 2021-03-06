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
                var patients = await _patientRepository.GetAll(x=>!x.Void)
                    .Include(x=>x.Contacts)
                    .Include(x=>x.Death)
                    .Include(x=>x.Employers)
                    .Include(x=>x.Guardians)
                    .ToListAsync();
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
                var patient = await _patientRepository.GetAll(x => x.Id==id)
                    .Include(x=>x.Contacts)
                    .Include(x=>x.Death)
                    .Include(x=>x.Employers)
                    .Include(x=>x.Guardians)
                    .FirstOrDefaultAsync();
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
                var patient = await _patientRepository.GetAll(x=>x.Id==id).FirstOrDefaultAsync();
                if (patient == null)
                    return (true, id, "Patient Not Found(0)");
                patient.Void = true;
                patient.VoidDate=DateTime.Today;
                _patientRepository.Update(patient);
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
                if (id.IsNullOrEmpty())
                {
                    _patientRepository.Create(patient);
                }
                else
                {
                    _patientRepository.Update(patient);
                }
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

        public async Task<(bool IsSuccess, IEnumerable<Domain.Patient.Models.Patient> patients, string ErrorMessage)> SearchPatient(string searchString)
        {
            try
            {
                var result = await _patientRepository.SearchPatient(searchString);
                return (result.IsSuccess, result.patients, result.ErrorMessage);
            }
            catch (Exception e)
            {
                Log.Error("$patient Search Error : {e}");
                return (false, new List<Domain.Patient.Models.Patient>(), e.Message);
            }
        }
    }
}
