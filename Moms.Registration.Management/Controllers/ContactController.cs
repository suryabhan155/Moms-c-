using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Serilog;

namespace Moms.RegistrationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController: ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddContacts([FromBody] Contact contact)
        {
            try
            {
                var results = await _contactService.AddContact(contact);
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results =await  _contactService.LoadContacts();
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

        [HttpGet("PatientContacts/{patientId}")]
        public async Task<IActionResult> PatientContacts(Guid patientId)
        {
            try
            {
                var results = await _contactService.GetPatientContacts(patientId);
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContacts(Guid id)
        {
            try
            {
                var results = await _contactService.DeleteContact(id);
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
