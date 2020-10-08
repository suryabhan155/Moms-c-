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
    public class StoreAdjustmentController : ControllerBase
    {

        public readonly IMediator _IMediator;
        public readonly IStockAdjustmentService _Service;

        public StoreAdjustmentController(IMediator iMediator, IStockAdjustmentService service)
        {
            _IMediator = iMediator;
            _Service = service;
        }

        [HttpGet("lab/stock/adjustment")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _Service.LoadStockAdjustment();
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

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var results = _Service.GetStockAdjustment(id);
                if (results.IsSuccess)
                    return Ok(results.stockAdjustment);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStockAdjustment([FromBody] StockAdjustment stockAdjustment)
        {
            try
            {
                var results = await _Service.AddStockAdjustment(stockAdjustment);
                if (results.IsSuccess)
                    return Ok(results.stockAdjustment);
                return NotFound(results.ErrorMessage);
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
                var results = await _Service.DeleteStockAdjustment(id);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound(results);
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
