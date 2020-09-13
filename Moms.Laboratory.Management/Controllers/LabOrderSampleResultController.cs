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
    public class LabOrderSampleResultController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly ILabOrderSampleResultService _LabOrderSampleResultService;

        public LabOrderSampleResultController(IMediator iMediator, ILabOrderSampleResultService labOrderSampleResultService)
        {
            _IMediator = iMediator;
            _LabOrderSampleResultService = labOrderSampleResultService;
        }

        [HttpGet("lab/orders/sample/result")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _LabOrderSampleResultService.LoadLabOrderSampleResult();
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

        [HttpGet("lab/order/sample/result")]
        public async Task<IActionResult> GetLabOrderSampleResults(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleResultService.GetLabOrderSampleResult(id);
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
        public async Task<IActionResult> DeleteLabOrderSampleResult(Guid id)
        {
            try
            {
                var result = await _LabOrderSampleResultService.DeleteLabOrderSampleResult(id);
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
        public async Task<IActionResult> AddLabOrderSampleResult([FromBody] LabOrderSampleResult labOrderSampleResult)
        {
            try
            {
                var results = await _LabOrderSampleResultService.AddLabOrderSampleResut(labOrderSampleResult);
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
