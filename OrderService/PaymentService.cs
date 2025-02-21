using System;

namespace OrderService
{
    public class PaymentService
    {
        public int ProcessPayment(Payment? payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            if (payment.Amount <= 0)
            {
                throw new ArgumentException("El monto del pago debe ser mayor a cero.");
            }

            // Aquí iría la lógica de procesamiento del pago
            // Por ahora solo retornamos el ID del pago
            return payment.Id;
        }
    }
}