using BarberShop.Communication.Enums;
using BarberShop.Communication.Request;
using BarberShop.Communication.Responses;
using BarberShop.Exception.ExceptionsBase;

namespace BarberShop.Application.UseCases.Invoices.Register
{
    public class RegisterInvoiceUseCase
    {
        public ResponseInvoiceJson Execute(RequestInvoiceJson request) 
        {
            return new ResponseInvoiceJson();
        }

        private void Validate(RequestInvoiceJson request)
        {
            var validator = new RegisterInvoiceValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
