namespace OrderService {
    public class PaymentService {
        public int ProcessPayment(Payment? payment) {
            if (payment == null) {
                throw new ArgumentNullException(nameof(payment), "El pago no puede ser nulo.");
            }
            if (payment.Amount <= 0) {
                throw new ArgumentException("El monto del pago debe ser mayor a cero.", nameof(payment.Amount));
            }

            // Aquí se podría agregar lógica adicional, como confirmar con un procesador de pagos externo.
            
            return payment.Id; // Simulando un ID de transacción exitoso.
        }
    }

    public class Payment {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; } // Asociado a un pedido existente
    }
}