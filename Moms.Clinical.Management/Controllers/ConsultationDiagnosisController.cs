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
    public class ConsultationDiagnosisController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly IConsultationDiagnosisService _ConsultationDiagnosisService;

        public ConsultationDiagnosisController(IMediator iMediator, IConsultationDiagnosisService consultationService)
        {
            _IMediator = iMediator;
            _ConsultationDiagnosisService = consultationService;
        }

        [HttpGet("lab/consultations")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ConsultationDiagnosisService.LoadConsultationDiagnosis();
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
        public async Task<IActionResult> GetConsultationDiagnosis(Guid id)
        {
            try
            {
                var result = await _ConsultationDiagnosisService.GetConsultationDiagnosis(id);
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
        public async Task<IActionResult> DeleteConsultationDiagnosis(Guid id)
        {
            try
            {
                var result = await _ConsultationDiagnosisService.DeleteConsultationDiagnosis(id);
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
        public async Task<IActionResult> AddConsultationDiagnosis([FromBody] ConsultationDiagnosis consultation)
        {
            try
            {
                var results = await _ConsultationDiagnosisService.AddConsultationDiagnosis(consultation);
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
