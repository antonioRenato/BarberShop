using BarberShop.Communication.Enums;
using BarberShop.Communication.Request;
using BarberShop.Communication.Responses;

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
            if (string.IsNullOrWhiteSpace(request.Description))
                throw new ArgumentException("The Description is required!");

            if (request.Amount <= 0)
                throw new ArgumentException("The amount must be greater than zero");

            var resultOfCompareDate = DateTime.Compare(request.Date, DateTime.UtcNow);

            if (resultOfCompareDate > 0)
                throw new ArgumentException("The date is in the future.");

            var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
            var JobTypeIsValid = Enum.IsDefined(typeof(JobType), request.JobType);

            if (!paymentTypeIsValid)
                throw new ArgumentException("Payment Type does not exist in the current request");

            if (!JobTypeIsValid)
                throw new ArgumentException("Job Type does not exist in the current request");
        }
    }
}
