using BarberShop.Communication.Enums;
using BarberShop.Communication.Request;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterInvoiceJsonBuilder
    {
        public RequestInvoiceJson Build()
        {
            return new Faker<RequestInvoiceJson>()
                .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(r => r.Date, faker => faker.Date.Soon())
                .RuleFor(r => r.JobType, faker => faker.PickRandom<JobType>())
                .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
                .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
        }
    }
}
