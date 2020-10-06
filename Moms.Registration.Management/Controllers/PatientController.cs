using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Serilog;

namespace Moms.RegistrationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPatientService _patientService;
        private readonly IPatientGridRepository _patientGridRepository;

        public PatientController(IMediator  mediator, IPatientService patientService, IPatientGridRepository patientGridRepository)
        {
            _mediator = mediator;
            _patientService = patientService;
            _patientGridRepository = patientGridRepository;
        }

        [HttpPost]
        public async Task<IActionResult>  AddPatient([FromBody] Patient patient)
        {
            try
            {
                var results = await _patientService.AddPatient(patient);
                if (results.IsSuccess)
                    return Ok(results.patients);
                return NotFound(results.ErrorMEssage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _patientService.LoadPatients();
                if (results.IsSuccess)
                    return Ok(results.patients);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("Patient/All/")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var result = await _patientGridRepository.AllPatients();
                if (result.IsSuccess)
                    return Ok(result.patientGrids);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            try
            {
                var results = await _patientService.GetPatient(id);
                if (results.IsSuccess)
                    return Ok(results.patient);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("search/{searchString}")]
        public async Task<IActionResult> PatientSearch(string searchString)
        {
            try
            {
                var result = await _patientService.SearchPatient(searchString);
                if (result.IsSuccess)
                    return Ok(result.patients);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error Searching Patients ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("PatientSearch/{searchstring}")] /* returns patients with decoded lookupItem names*/
        public async Task<IActionResult> SearchPatient(string searchstring)
        {
            try
            {
                var result = await _patientGridRepository.SearchPatient(searchstring);
                if (result.IsSuccess)
                    return Ok(result.patientGrids);
                return BadRequest(result.ErrorMessage);
                {

                }
            }
            catch (Exception e)
            {
                var msg = $"Error Searching Patients ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                var results = await _patientService.DeletePatient(id);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
