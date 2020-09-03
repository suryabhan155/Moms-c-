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
    public class LabOrderSampleController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly ILabOrderSampleService _LabOrderSampleService;

        public LabOrderSampleController(IMediator iMediator, ILabOrderSampleService labOrderSampleService)
        {
            _IMediator = iMediator;
            _LabOrderSampleService = labOrderSampleService;
        }

        [HttpGet("lab/orders/samples")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _LabOrderSampleService.LoadLabOrderSamples();
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

        [HttpGet("lab/order")]
        public async Task<IActionResult> GetLabOrderSample(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleService.GetLabOrderSample(id);
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
        public async Task<IActionResult> DeleteLabOrderSample(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleService.DeleteLabOrderSample(id);
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
        public async Task<IActionResult> AddLabOrderSample([FromBody] LabOrderSample labOrderSample)
        {
            try
            {
                var results = await _LabOrderSampleService.AddLabOrderSample(labOrderSample);
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
