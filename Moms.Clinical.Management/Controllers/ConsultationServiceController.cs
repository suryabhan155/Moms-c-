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
    public class ConsultationServiceController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly IConsultationServiceService _ConsultationServiceService;

        public ConsultationServiceController(IMediator iMediator, IConsultationServiceService consultationService)
        {
            _IMediator = iMediator;
            _ConsultationServiceService = consultationService;
        }

        [HttpGet("lab/consultations")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ConsultationServiceService.LoadConsultationServices();
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
        public async Task<IActionResult> GetConsultationService(Guid id)
        {
            try
            {
                var result = await _ConsultationServiceService.GetConsultationServices(id);
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
        public async Task<IActionResult> DeleteConsultationService(Guid id)
        {
            try
            {
                var result = await _ConsultationServiceService.DeleteConsultationService(id);
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
        public async Task<IActionResult> AddConsultationService([FromBody] ConsultationService consultation)
        {
            try
            {
                var results = await _ConsultationServiceService.AddConsultationService(consultation);
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
