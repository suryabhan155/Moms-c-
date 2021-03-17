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
    public class BillingSubItemTypeController : ControllerBase
    {
        private readonly IBillingSubItemTypeService _itemSubMasterService;
        public BillingSubItemTypeController(IBillingSubItemTypeService subitem)
        {
            _itemSubMasterService = subitem;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _itemSubMasterService.GetAllBillingItem();
                if (result.IsSuccess)
                    return Ok(result.response);
                return BadRequest(result.response);
            }
            catch (Exception ex)
            {
                var msg = $"Error Loading ";
                Log.Error(ex.Message);
                return StatusCode(500, $"{msg} {ex.Message}");
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var result = await _itemSubMasterService.GetBillingItemById(Id);
                if (result.IsSuccess)
                    return Ok(result.response);
                return BadRequest(result.response);
            }
            catch (Exception ex)
            {
                var msg = $"Error Loading ";
                Log.Error(ex.Message);
                return StatusCode(500, $"{msg} {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BillingSubItemType subitem)
        {
            try
            {
                var result = await _itemSubMasterService.CreateItem(subitem);
                if (result.IsSuccess)
                    return Ok(result.response);
                return BadRequest(result.response);
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
                var result = await _itemSubMasterService.Delete(Id);
                if (result.IsSuccess)
                    return Ok(result.response);
                return BadRequest(result.response);
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
