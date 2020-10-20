using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Application.Billing.Services;
using Moms.Revenue.Core.Domain.Billing.Models;
using Serilog;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientBillingController:ControllerBase
    {
        private readonly ClientBillingService _clientBillingService;

        public ClientBillingController(ClientBillingService clientBillingService)
        {
            _clientBillingService = clientBillingService;
        }

        [HttpGet("ClientBill")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _clientBillingService.GetAllBilling();
                if (result.IsSuccess)
                    return Ok(result.clientBills);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("clientBill/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _clientBillingService.GetAllBilling();
                if (result.IsSuccess)
                    return Ok(result.clientBills);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientBill clientBill)
        {
            try
            {
                var result = await _clientBillingService.Create(clientBill);
                if (result.IsSuccess)
                    return Ok(result.clientBill);
                return BadRequest(result.ErrorMessage);
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
                var result = await _clientBillingService.Delete(Id);
                if (result.IsSuccess)
                    return Ok(result.ErrorMEssage);
                return BadRequest(result.ErrorMEssage);
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
