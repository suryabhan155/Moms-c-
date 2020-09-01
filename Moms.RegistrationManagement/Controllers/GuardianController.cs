using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Service;
using Serilog;

namespace Moms.RegistrationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardianController: ControllerBase
    {
        private readonly IGuardianService _guardianService;

        public GuardianController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        public async Task<IActionResult> AddGuardian([FromBody] Guardian guardian)
        {
            try
            {
                var results = await _guardianService.AddGuardian(guardian);
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

        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _guardianService.LoadGuardians();
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

        [HttpGet("PatientGuardian/{patientId}")]
        public async Task<IActionResult> GetPatientGuardian(Guid patientId)
        {
            try
            {
                var results = await _guardianService.GetPatientGuardians(patientId);
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

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteGuardian(Guid id)
        {
            try
            {
                var results = await _guardianService.DeleteGuardian(id);
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
