using Microsoft.AspNetCore.Mvc;
using SolidPrincipalWithDecoratorPatternAndDbContext.Model;
using SolidPrincipalWithDecoratorPatternAndDbContext.Service;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{tenantId}")]
        public async Task<IActionResult> ProcessPayment(string tenantId, [FromBody] PaymentDetails paymentDetails)
        {
            await _paymentService.ProcessAndSavePaymentAsync(tenantId, paymentDetails);
            return Ok("Payment processed and saved.");
        }
    }
}
