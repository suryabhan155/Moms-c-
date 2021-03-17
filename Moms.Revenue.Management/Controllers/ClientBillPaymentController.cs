using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientBillPaymentController:ControllerBase
    {
        private readonly IClientBillPaymentService _clientBillPaymentService;

        public ClientBillPaymentController(IClientBillPaymentService clientBillPaymentService)
        {
            _clientBillPaymentService = clientBillPaymentService;
        }

        [HttpGet("clientBillPayment")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _clientBillPaymentService.GetAllClientBillPayment();
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

        [HttpGet("clientBillPayment/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _clientBillPaymentService.GetClientBillPayment(Id);
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientBillPayment clientBillPayment)
        {
            try
            {
                var result =await _clientBillPaymentService.Create(clientBillPayment);
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

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _clientBillPaymentService.Delete(Id);
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
