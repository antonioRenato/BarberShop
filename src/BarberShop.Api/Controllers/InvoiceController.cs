using BarberShop.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestInvoiceJson request)
        {
            return Created();
        }
    }
}
