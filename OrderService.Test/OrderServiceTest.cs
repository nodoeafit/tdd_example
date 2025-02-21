namespace OrderService.Tests
{
    using Xunit;
    using System;
    using System.Collections.Generic;
    using OrderServiceNamespace;
    using PaymentServiceNamespace;
    using MenuServiceNamespace;

    public class OrderServiceTest
    {
        private readonly OrderService orderService;
        private readonly PaymentService paymentService;
        private readonly MenuService menuService;

        public OrderServiceTest()
        {
            paymentService = new PaymentService();
            menuService = new MenuService();
            orderService = new OrderService(paymentService, menuService);
        }

        [Fact]
        // Crea una orden exitosa
        public void CreateOrder_ShouldProcessOrderSuccessfully()
        {
            var order = new Order { Id = 1 };

            // El pago de la orden
            var payment = new Payment
            {
                MetodoDePago = "CreditCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2029, 12, 1),
                CVV = "123"
            };

            // Los items que hacen parte de la orden
            var items = new List<string> { "Hamburguesa", "Papas Fritas" };

            var orderId = orderService.CreateOrder(order, payment, items);

            Assert.Equal(1, orderId);
            Assert.True(order.IsProcessed);
            Assert.Equal(8.98m, order.Amount); // 5.99 + 2.99
        }

        [Fact]
        // Crea una orden con pago fallido
        public void CreateOrder_ShouldThrowExceptionForInvalidPayment()
        {
            var order = new Order { Id = 1 };
            var payment = new Payment
            {
                MetodoDePago = "CreditCard",
                NumeroDeTarjeta = "1234567890123456",
                NombreEnTarjeta = "Frank Ocean",
                Vencimiento = new DateTime(2022, 12, 1), // Tarjeta expirada
                CVV = "123"
            };

            // Los items que hacen parte de la orden
            var items = new List<string> { "Hamburguesa", "Papas Fritas" };

            Assert.Throws<InvalidOperationException>(() => orderService.CreateOrder(order, payment, items));
        }
    }
}