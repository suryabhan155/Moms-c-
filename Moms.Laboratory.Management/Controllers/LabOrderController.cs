using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Serilog;

namespace Moms.Laboratory.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabOrderController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly ILabOrderService _LabOrderService;

        public LabOrderController(IMediator iMediator, ILabOrderService labOrderService)
        {
            _IMediator = iMediator;
            _LabOrderService = labOrderService;
        }

        [HttpGet("lab/orders")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _LabOrderService.LoadLabOrders();
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
        public async Task<IActionResult> GetLabOrder(Guid id)
        {
            try
            {
                var result = await _LabOrderService.GetLabOrder(id);
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
        public async Task<IActionResult> DeleteLabOrder(Guid id)
        {
            try
            {
                var result = await _LabOrderService.DeleteLabOrder(id);
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
    }
}
