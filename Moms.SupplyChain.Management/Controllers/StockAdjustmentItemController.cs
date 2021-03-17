using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Serilog;

namespace Moms.SupplyChain.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockAdjustmentItemController : ControllerBase
    {

        public readonly IMediator _IMediator;
        public readonly IStockAdjustmentItemService _Service;

        public StockAdjustmentItemController(IMediator iMediator, IStockAdjustmentItemService service)
        {
            _IMediator = iMediator;
            _Service = service;
        }

        [HttpGet("lab/stock/adjustmentItem")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _Service.LoadStockAdjustmentItem();
                if (results.IsSuccess)
                    return Ok(results.response);
                return NotFound(results.response);

            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var results = _Service.GetStockAdjustmentItem(id);
                if (results.IsSuccess)
                    return Ok(results.response);
                return NotFound(results.response);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStockAdjustmentItem([FromBody] StockAdjustmentItem stockAdjustmentitem)
        {
            try
            {
                var results = await _Service.AddStockAdjustmentItem(stockAdjustmentitem);
                if (results.IsSuccess)
                    return Ok(results.response);
                return NotFound(results.response);
            }
            catch (Exception e)
            {
                var msg = $"Error saving ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var results = await _Service.DeleteStockAdjustmentItem(id);
                if (results.IsSuccess)
                    return Ok(results.response);
                return NotFound(results.response);
            }
            catch (Exception e)
            {
                var msg = $"Error deleting ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
