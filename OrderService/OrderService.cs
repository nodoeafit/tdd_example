namespace OrderServiceNamespace
{
    using PaymentServiceNamespace;
    using MenuServiceNamespace;
    using System;
    using System.Collections.Generic;

    public class OrderService
    {
        private readonly PaymentService paymentService;
        private readonly MenuService menuService;

        public OrderService(PaymentService paymentService, MenuService menuService)
        {
            this.paymentService = paymentService;
            this.menuService = menuService;
        }

        public int CreateOrder(Order order, Payment payment, List<string> items)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (items == null || items.Count == 0) throw new ArgumentException("La orden debe contener al menos un item.");
            
            // Calcula el total usando el Menu
            decimal totalAmount = 0;
            foreach (var item in items)
            {
                totalAmount += menuService.GetPrice(item);
            }

            // Establece el valor de la orden
            order.Amount = totalAmount;

            // Procesa el pago usando el PaymentService
            payment.Amount = totalAmount;
            var paymentResult = paymentService.ProcessPayment(payment);

            if (!paymentResult.IsSuccess)
            {
                throw new InvalidOperationException("El pago falló: " + paymentResult.Message);
            }

            order.IsProcessed = true;
            return order.Id;
        }
    }
}