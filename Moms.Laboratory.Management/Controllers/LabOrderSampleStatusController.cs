using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Serilog;

namespace Moms.Laboratory.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabOrderSampleStatusController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly ILabOrderSampleStatusService _LabOrderSampleStatusService;

        public LabOrderSampleStatusController(IMediator iMediator, ILabOrderSampleStatusService labOrderSampleStatusService)
        {
            _IMediator = iMediator;
            _LabOrderSampleStatusService = labOrderSampleStatusService;
        }

        [HttpGet("lab/orders/sample/status")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _LabOrderSampleStatusService.LoadLabOrderSampleStatus();
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

        [HttpGet("lab/order/sample/status")]
        public async Task<IActionResult> GetLabOrderSampleStatus(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleStatusService.GetLabOrderSampleStatus(id);
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
        public async Task<IActionResult> DeleteLabOrderSampleStatus(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleStatusService.DeleteLabOrderSampleStatus(id);
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
        public async Task<IActionResult> AddLabOrderSampleStatus([FromBody] LabOrderSampleStatus labOrderSampleStatus)
        {
            try
            {
                var results = await _LabOrderSampleStatusService.AddLabOrderSampleStatus(labOrderSampleStatus);
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
