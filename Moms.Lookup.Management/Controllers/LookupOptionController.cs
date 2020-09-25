using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Lookup.Core.Domain.Options;
using Serilog;

namespace Moms.Lookup.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupOptionController : ControllerBase
    {
        private readonly ILookupOptionRepository _optionRepository;

        public LookupOptionController(ILookupOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        [HttpGet("optionsById/{id}")]
         public async Task<IActionResult> GetLookupOptionsById(Guid id)
         {
             try
             {
                 var result = await _optionRepository.GetLookupOptionsById(id);
                 if (result.IsSuccess)
                     return Ok(result.lookupOptions);
                 return BadRequest(result.ErrorMessage);
             }
             catch (Exception e)
             {
                 var msg = $"Error loading ";
                 Log.Error(e, msg);
                 return StatusCode(500, $"{msg} {e.Message}");
             }
         }

         [HttpGet("optionsByName/{name}")]
        public async Task<IActionResult> GetLookupOptionsByName(string name)
         {
             try
             {
                 var results = await _optionRepository.GetLookupOptionsByName(name);
                 if (results.IsSuccess)
                     return Ok(results.lookupOptions);
                 return BadRequest($"{results.ErrorMessage}");
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
