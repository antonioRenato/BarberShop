using BarberShop.Communication.Enums;

namespace BarberShop.Communication.Request
{
    public class RequestInvoiceJson
    {
        public JobType JobType { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
    }
}
