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
    public class ConsultationComplaintController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly IConsultationComplaintService _ConsultationComplaintService;

        public ConsultationComplaintController(IMediator iMediator, IConsultationComplaintService consultationService)
        {
            _IMediator = iMediator;
            _ConsultationComplaintService = consultationService;
        }

        [HttpGet("lab/consultations")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ConsultationComplaintService.LoadConsultationComplaints();
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
        public async Task<IActionResult> GetConsultationComplaint(Guid id)
        {
            try
            {
                var result = await _ConsultationComplaintService.GetConsultationComplaint(id);
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
        public async Task<IActionResult> DeleteConsultationComplaint(Guid id)
        {
            try
            {
                var result = await _ConsultationComplaintService.DeleteConsultationComplaint(id);
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
        public async Task<IActionResult> AddConsultationComplaint([FromBody] ConsultationComplaint consultation)
        {
            try
            {
                var results = await _ConsultationComplaintService.AddConsultationComplaint(consultation);
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
