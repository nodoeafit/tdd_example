
namespace PaymentService.Tests
{
    using Xunit;
    using PaymentServiceNamespace;

    public class PaymentServiceTest
    {
        [Fact]
        //Prueba el procesamiento de pago con tarjeta de credito
        public void PaymentProcessingWithCreditCardTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "CreditCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2029, 12, 1),
                CVV = "123"
            };

            // Ejecución
            var result = paymentService.ProcessPayment(payment);

            // Verificación
            Assert.True(result.IsSuccess);
            Assert.Equal("Pago exitoso", result.Message);
        }

        [Fact]
        //Prueba el procesamiento de pago con efectivo
        public void PaymentProcessingWithCashTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "Cash",
                DineroRecibido = 100
            };

            // Ejecución
            var result = paymentService.ProcessPayment(payment);

            // Verificación
            Assert.True(result.IsSuccess);
            Assert.Equal("Pago exitoso", result.Message);
        }

        [Fact]
        // Prueba el procesamiento de pago con efectivo insuficiente
        public void PaymentProcessingWithInsufficientCashTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "Cash",
                DineroRecibido = 50 // efectivo insuficiente
            };

            // Ejecución
            var result = paymentService.ProcessPayment(payment);

            // Verificación
            Assert.False(result.IsSuccess);
            Assert.Equal("Pago fallido: efectivo insuficiente", result.Message);
        }

        [Fact]
        //Prueba el procesamiento de pago con tarjeta de crédito inválida
        public void PaymentFailureHandlingTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "CreditCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2022, 12, 1),
                CVV = "123"
            };

            // Ejecución
            var result = paymentService.ProcessPayment(payment);

            // Verificación
            Assert.False(result.IsSuccess);
            Assert.Equal("Pago fallido: tarjeta inválida", result.Message);
        }

        [Fact]
        //Prueba el procesamiento de pago con tarjeta de débito inválida
        public void PaymentFailureHandlingWithDebitCardTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "DebitCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2022, 12, 1),
                CVV = "123"
            };

            // Ejecución
            var result = paymentService.ProcessPayment(payment);

            // Verificación
            Assert.False(result.IsSuccess);
            Assert.Equal("Pago fallido: tarjeta inválida", result.Message);
        }

        [Fact]
        //Prueba el calculo del total
        public void TotalAmountCalculationTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "CreditCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2029, 12, 1),
                CVV = "123"
            };

            // Ejecución
            var result = paymentService.CalculateTotalAmount(payment);

            // Verificación
            Assert.Equal(100, result);
        }

        [Fact]
        //Prueba el calculo del total con efectivo
        public void TotalAmountCalculationWithCashTest()
        {
            // Preparación
            var paymentService = new PaymentServiceNamespace.PaymentService();
            var payment = new PaymentServiceNamespace.Payment
            {
                Amount = 100,
                MetodoDePago = "Cash",
                DineroRecibido = 100
            };

            // Ejecución
            var result = paymentService.CalculateTotalAmount(payment);

            // Verificación
            Assert.Equal(100, result);
        }
    }

}

