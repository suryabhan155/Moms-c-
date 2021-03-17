using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;
using SQLitePCL;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientBillingTypeController:ControllerBase
    {
        private readonly IBillingTypeService _billingTypeService;

        public ClientBillingTypeController(IBillingTypeService billingTypeService)
        {
            _billingTypeService = billingTypeService;
        }

        [HttpGet("BillingType")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _billingTypeService.GetAllBillingType();
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("BillingType/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _billingTypeService.GetBillType(Id);
                if(result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BillingType billingType )
        {
            try
            {
                var result = await _billingTypeService.Create(billingType);
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _billingTypeService.Delete(Id);
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
