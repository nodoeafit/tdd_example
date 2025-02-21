namespace OrderService
{
    public class PaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor que cero.");
            }

            return true;
        }

        public bool IsPaymentSuccessful(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId), "El ID de la transacción no puede ser nulo o vacío");


            return true;
        }

    }
}
