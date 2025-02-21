using OrderService.Models;

namespace OrderService.Services
{
    public class PaymentService
    {

        public int CreatePayment(Payment? payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException();
            }

            return payment.Id;
        }

        public string? GetStatusPayment(Payment? payment)
        {

            if (payment == null)
            {
                throw new ArgumentNullException();
            }

            if (payment.Status == "Failed")
            {
                throw new InvalidOperationException("El pago ha fallado.");
            }

            return payment.Status;
        }
    }
}