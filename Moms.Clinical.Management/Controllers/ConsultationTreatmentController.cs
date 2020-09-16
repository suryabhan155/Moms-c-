using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.Clinical.Core.Domain.Consultation.Services;
using Serilog;

namespace Moms.Clinical.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationTreatmentController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly IConsultationTreatmentService _ConsultationTreatmentService;

        public ConsultationTreatmentController(IMediator iMediator, IConsultationTreatmentService consultationService)
        {
            _IMediator = iMediator;
            _ConsultationTreatmentService = consultationService;
        }

        [HttpGet("lab/consultations")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ConsultationTreatmentService.LoadConsultationTreatments();
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound();

            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("lab/consultation")]
        public async Task<IActionResult> GetConsultationTreatments(Guid id)
        {
            try
            {
                var result = await _ConsultationTreatmentService.GetConsultationTreatments(id);
                if (result.IsSuccess)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConsultationTreatment(Guid id)
        {
            try
            {
                var result = await _ConsultationTreatmentService.DeleteConsultationTreatment(id);
                if (result.IsSuccess)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddConsultationTreatment([FromBody] ConsultationTreatment consultation)
        {
            try
            {
                var results = await _ConsultationTreatmentService.AddConsultationTreatment(consultation);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
