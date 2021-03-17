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
    public class DeathController: ControllerBase
    {
        private readonly IDeathService _deathService;

        public DeathController(IDeathService deathService)
        {
            _deathService = deathService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDeath([FromBody] Death death)
        {
            try
            {
                var results = await _deathService.AddDeath(death);
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
                var results = await _deathService.LoadDeaths();
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

        [HttpGet("PatientDeath/{patientId}")]
        public async Task<IActionResult> GetPatientDeathStatus(Guid patientId)
        {
            try
            {
                var results = await _deathService.GetPatientDeath(patientId);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteDeathStatus(Guid id)
        {
            try
            {
                var results = await _deathService.DeleteDeath(id);
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
