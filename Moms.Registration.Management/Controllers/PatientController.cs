using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.NewIdProviders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Moms.SharedKernel.Model;
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
        private readonly IBus _bus;

        public PatientController(IMediator  mediator, IPatientService patientService, IPatientGridRepository patientGridRepository, IBus bus)
        {
            _mediator = mediator;
            _patientService = patientService;
            _patientGridRepository = patientGridRepository;
            _bus = bus;
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

        [HttpGet("testRabbitMQ")]
        public async void testRabbitMQ()
        {
            string id = "13e267d2-8915-4ae7-88a6-f0c2146bee84";
            string id2 = "13e267d2-8915-4ae7-88a6-f0c2146bee85";
            Uri uri = new Uri("rabbitmq://localhost/patientqueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            var bill = new BillDto()
            {
                BillDate = DateTime.Now,
                ItemId = new Guid(id),
                PatientId = new Guid(id2),
                Qty = 10
            };
            await endPoint.Send(bill);
        }
    }
}
