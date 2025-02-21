namespace PaymentService
{
    using PaymentNamespace;
    public class PaymentService
    {
        public void ProcessPayment(Payment payment)
        {
            // Procesamiento de pago
            if (payment.MetodoDePago == "CreditCard" || payment.MetodoDePago == "DebitCard")
            {
                // Procesamiento de pago con tarjeta
                if (!IsCardValid(payment))
                {
                    return new PaymentResult
                    {
                        IsSuccess = false,
                        Message = "Pago fallido: tarjeta inválida"
                    };
                }
                
                if (!HasSufficientFunds(payment))
                {
                    return new PaymentResult
                    {
                        IsSuccess = false,
                        Message = "Pago fallido: fondos insuficientes"
                    };
                }
            }

            else if (payment.MetodoDePago == "Cash")
            {
                // Procesamiento de pago con efectivo
                if (payment.DineroRecibido >= payment.Amount)
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Pago exitoso"
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        IsSuccess = false,
                        Message = "Pago fallido: efectivo insuficiente"
                    };
                }
            }

            return new PaymentResult { IsSuccess = true, Message = "Pago exitoso" };
        }

        private bool IsCardValid(Payment payment)
        {
            // Verifica que tenga la cantidad de digitos correcta y que no haya expirado
            return payment.CardNumber.Length == 16 && payment.Vencimiento > DateTime.Now;
        }

        private bool HasSufficientFunds(Payment payment)
        {
            // Verifica que haya suficientes fondos en la tarjeta (este es solo en ejemplo, falta logica real)
            return payment.Amount <= 1000;
        }

        public decimal CalculateTotalAmount(Payment payment)
        {
            // Calcula el monto total a pagar (pendiente de implementar)
            return payment.Amount;
        }
    }
}
