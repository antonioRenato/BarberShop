using BarberShop.Application.UseCases.Invoices.Register;
using BarberShop.Communication.Enums;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Invoices.Register
{
    public class RegisterInvoiceValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            var validator = new RegisterInvoiceValidator();
            var request = RequestRegisterInvoiceJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Title_Empty()
        {
            var validator = new RegisterInvoiceValidator();
            var request = RequestRegisterInvoiceJsonBuilder.Build();
            request.Description = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The description is required!"));
        }

        [Fact]
        public void Error_Date_Future()
        {
            var validator = new RegisterInvoiceValidator();
            var request = RequestRegisterInvoiceJsonBuilder.Build();
            request.Date = DateTime.Now.AddDays(1);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The date cannot be in the future."));
        }

        [Fact]
        public void Error_JobType_Invalid()
        {
            var validator = new RegisterInvoiceValidator();
            var request = RequestRegisterInvoiceJsonBuilder.Build();
            request.JobType = (JobType)500;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Job Type does not exist in the current request"));
        }
    }
}
