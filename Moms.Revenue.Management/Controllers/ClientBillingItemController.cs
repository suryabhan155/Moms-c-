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
    public class ClientBillingItemController:ControllerBase
    {
        private readonly IClientBillingItemService _clientBillingItemService;

        public ClientBillingItemController(IClientBillingItemService clientBillingItemService)
        {
            _clientBillingItemService = clientBillingItemService;
        }

        [HttpGet("clientBillingItem")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _clientBillingItemService.GetAllClientBillingItem();
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

        [HttpGet("clientBillingItem/{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _clientBillingItemService.GetClientBillingItem(Id);
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
        public async Task<IActionResult> Post([FromBody] ClientBillingItem clientBillingItem)
        {
            try
            {
                var result = await _clientBillingItemService.Create(clientBillingItem);
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
                var result = await _clientBillingItemService.Delete(Id);
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
