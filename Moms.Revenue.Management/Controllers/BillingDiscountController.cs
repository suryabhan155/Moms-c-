using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Application.Billing.Services;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingDiscountController:ControllerBase
    {
        private readonly IBillingDiscountService _billingDiscountService;

        public BillingDiscountController(IBillingDiscountService billingDiscountService)
        {
            _billingDiscountService = billingDiscountService;
        }

        [HttpGet("BillingDiscount")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _billingDiscountService.GetAllBillingDiscounts();
                if (result.IsSuccess)
                    return Ok(result.model);
                else
                    return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("BillingDiscount/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _billingDiscountService.GetBillingDiscount(Id);
                if (result.IsSuccess)
                    return Ok(result.model);
                else
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
        public async Task<IActionResult> Post([FromBody] BillingDiscount billingDiscount)
        {
            try
            {
                var result = await _billingDiscountService.Create(billingDiscount);
                if (result.IsSuccess)
                    return Ok(result.model);
                else
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
                var result = await _billingDiscountService.Delete(Id);
                if (result.IsSuccess)
                    return Ok(result.model);
                else
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
