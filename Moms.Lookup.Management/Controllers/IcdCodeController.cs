using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Lookup.Core.Domain.ICD.Services;
using Serilog;

namespace Moms.Lookup.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcdCodeController : ControllerBase
    {
        public readonly IIcdCodeService _IcdCodeService;

        public IcdCodeController(IIcdCodeService icdCodeService)
        {
            _IcdCodeService = icdCodeService;
        }

        [HttpGet("diagnosis/search")]
        public async Task<IActionResult> SearchDiagnosis(String icdCode)
        {
            try
            {
                var result = await _IcdCodeService.SearchDiagnosis(icdCode);
                if (result.IsSuccess)
                    return Ok(result);
                return NotFound();
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
