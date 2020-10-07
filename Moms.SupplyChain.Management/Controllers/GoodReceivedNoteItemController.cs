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
    public class GoodReceivedNoteItemController : ControllerBase
    {

        public readonly IMediator _IMediator;
        public readonly IGoodReceivedNoteItemService _Service;

        public GoodReceivedNoteItemController(IMediator iMediator, IGoodReceivedNoteItemService service)
        {
            _IMediator = iMediator;
            _Service = service;
        }

        [HttpGet("lab/grn/items")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _Service.LoadGoodReceivedNoteItems();
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
                var results = _Service.GetGoodReceivedNoteItems(id);
                if (results.IsSuccess)
                    return Ok(results.goodReceivedNoteItems);
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
        public async Task<IActionResult> AddGoodReceivedNoteItems([FromBody] GoodReceivedNoteItem goodReceivedNoteItem)
        {
            try
            {
                var results = await _Service.AddGoodReceivedNoteItems(goodReceivedNoteItem);
                if (results.IsSuccess)
                    return Ok(results.goodReceivedNoteItem);
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
                var results = await _Service.DeleteGoodReceivedNoteItems(id);
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
