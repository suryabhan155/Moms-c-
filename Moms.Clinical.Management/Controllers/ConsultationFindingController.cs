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
    public class ConsultationFindingController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly IConsultationFindingService _ConsultationFindingService;

        public ConsultationFindingController(IMediator iMediator, IConsultationFindingService consultationService)
        {
            _IMediator = iMediator;
            _ConsultationFindingService = consultationService;
        }

        [HttpGet("lab/consultations")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ConsultationFindingService.LoadConsultationFindings();
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
        public async Task<IActionResult> GetConsultationFinding(Guid id)
        {
            try
            {
                var result = await _ConsultationFindingService.GetConsultationFindings(id);
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
        public async Task<IActionResult> DeleteConsultationFinding(Guid id)
        {
            try
            {
                var result = await _ConsultationFindingService.DeleteConsultationFinding(id);
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
        public async Task<IActionResult> AddConsultationFinding([FromBody] ConsultationFinding consultation)
        {
            try
            {
                var results = await _ConsultationFindingService.AddConsultationFinding(consultation);
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
