using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moms.Clinical.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        private readonly IVitalsService _vitalsService;

        public VitalsController(IVitalsService vitalsService)
        {
            _vitalsService = vitalsService;
        }

        // GET: api/<VitalsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _vitalsService.LoadVitals();
                if (results.IsSuccess)
                    return Ok(results.vitals);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        // GET api/<VitalsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var results = _vitalsService.GetVitals(id);
                if (results.IsSuccess)
                    return Ok(results.vital);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("getPatientVitals/{patientId}")]
        public async Task<IActionResult> GetPatientVitals(Guid patientId)
        {
            try
            {
                var results = await _vitalsService.GetPatientVitals(patientId);
                if (results.IsSuccess)
                    return Ok(results.vitals);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        // POST api/<VitalsController>
        [HttpPost]
        public async Task<IActionResult> AddVitals([FromBody] Vital vitals)
        {
            try
            {
                var results = await _vitalsService.AddVitals(vitals);
                if (results.IsSuccess)
                    return Ok(results.vitals);
                return NotFound(results.ErrorMEssage);
            }
            catch (Exception e)
            {
                var msg = $"Error saving ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        // DELETE api/<VitalsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var results = await _vitalsService.DeleteVitals(id);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error deleting ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
