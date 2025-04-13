using BarberShop.Communication.Enums;
using BarberShop.Communication.Request;
using FluentValidation;

namespace BarberShop.Application.UseCases.Invoices.Register
{
    public class RegisterInvoiceValidator : AbstractValidator<RequestInvoiceJson>
    {
        public RegisterInvoiceValidator()
        {
            RuleFor(invoice => invoice.Description).NotEmpty().WithMessage("The description is required!");
            RuleFor(invoice => invoice.Amount).GreaterThan(0).WithMessage("The Amount musst be grater than zero!");
            RuleFor(invoice => invoice.Date).GreaterThan(DateTime.UtcNow).WithMessage("The date cannot be in the future.");
            RuleFor(invoice => invoice.PaymentType).IsInEnum().WithMessage("Payment Type does not exist in the current request");
            RuleFor(invoice => invoice.JobType).IsInEnum().WithMessage("Job Type does not exist in the current request");
        }
    }
}
