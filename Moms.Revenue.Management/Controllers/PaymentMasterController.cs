using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMasterController : ControllerBase
    {
        private readonly IPaymentMasterService _paymentMaster;
        public PaymentMasterController(IPaymentMasterService paymentMaster)
        {
            _paymentMaster = paymentMaster;
        }
        [HttpGet("PaymentMethod")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _paymentMaster.GetAllPaymentMethod();
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception ex)
            {
                var msg = $"Error Loading ";
                Log.Error(ex.Message);
                return StatusCode(500,$"{msg} {ex.Message}");
            }
        }
        [HttpGet("BillType/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _paymentMaster.GetPaymentMethod(Id);
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception ex)
            {
                var msg = $"Error Loading ";
                Log.Error(ex.Message);
                return StatusCode(500, $"{msg} {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentMaster paymentMaster)
        {
            try
            {
                var result = await _paymentMaster.CreatePayment(paymentMaster);
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error Loading ";
                Log.Error(e.Message);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _paymentMaster.Delete(Id);
                if (result.IsSuccess)
                    return Ok(result.model);
                return BadRequest(result.model);
            }
            catch (Exception e)
            {
                var msg = $"Error Loading ";
                Log.Error(e.Message);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
