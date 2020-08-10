using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.RevenueManagement.Core.Domain.Billing;
using Serilog;

namespace Moms.RevenueManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public PaymentTypeController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var results = _billingService.LoadPaymentTypes();

                    return Ok(results);
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
