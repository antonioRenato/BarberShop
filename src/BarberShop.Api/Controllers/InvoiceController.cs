using BarberShop.Application.UseCases.Invoices.Register;
using BarberShop.Communication.Request;
using BarberShop.Communication.Responses;
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
            try
            {
                var useCase = new RegisterInvoiceUseCase().Execute(request);

                return Created(string.Empty, useCase);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Message);

                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("Unknown error");

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
