using System;
using System.Collections.Generic;
using System.IO;
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
    public class EmployerService: IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IMapper mapper, IEmployerRepository employerRepository)
        {
            _mapper = mapper;
            _employerRepository = employerRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<EmployerDto>, string ErrorMessage)> LoadEmployees()
        {
            IEnumerable<EmployerDto>  employerDtos=new List<EmployerDto>();
            try
            {
                var employer = await _employerRepository.GetAll().ToListAsync();
                if (employer == null)
                    return (false, employerDtos, "employer data not found");
                return (true, _mapper.Map<List<EmployerDto>>(employer) , "employer loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error in loading employers ");
                return (false, employerDtos, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<EmployerDto> employerDtos, string ErrorMessage)> GetPatientEmployees(Guid patientId)
        {
            IEnumerable<EmployerDto> employerDtos=new List<EmployerDto>();
            try
            {
                var employer = await _employerRepository.GetAll(x => x.PatientId == patientId).ToListAsync();
                if (employer == null)
                    return (false, employerDtos, "Patient employer NOT found");
                return (true, _mapper.Map<List<EmployerDto>>(employer),"employer successfully loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error getting patient employer");
                return (false, employerDtos, $"{e.Message}");

            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteEmployee(Guid id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    return (false, id, $"No Delete Id provided");
                _employerRepository.DeleteById(id);
                await _employerRepository.Save();
                return (true, id, $"employer with Id :{id} deleted successfully");
            }
            catch (Exception e)
            {
                Log.Error($"Error deleting employer details Id: {id}");
                return (false, id, e.Message);
            }
        }

        public Task<(bool IsSuccess, Employer employer, string ErrorMEssage)> AddEmployer(Domain.Patient.Models.Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
