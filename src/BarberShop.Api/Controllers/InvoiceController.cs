using BarberShop.Application.UseCases.Invoices.Register;
using BarberShop.Communication.Request;
using BarberShop.Communication.Responses;
using BarberShop.Exception.ExceptionsBase;
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
            var useCase = new RegisterInvoiceUseCase().Execute(request);

            return Created(string.Empty, useCase);
        }
    }
}
