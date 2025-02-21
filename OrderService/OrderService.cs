using System;
using System.Collections.Generic;

namespace OrderService 
{
    public class OrderService 
    {
        private readonly Dictionary<int, Order> _orders = new Dictionary<int, Order>();

        public int CreateOrder(Order? order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
          
            if(order.Amount <= 0)
            {
                throw new ArgumentException("El monto de la orden debe ser mayor a cero. Gracias.");
            }

            if(order.HasPromotion)
            {
                order.Amount = order.Amount * 0.9m;
            }

            _orders[order.Id] = order;
            return order.Id;   
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (!_orders.ContainsKey(order.Id))
            {
                throw new KeyNotFoundException($"Order con Id {order.Id} no encontrado");
            }

            _orders[order.Id] = order;
        }

        public void DeleteOrder(int orderId)
        {
            if (!_orders.ContainsKey(orderId))
            {
                throw new KeyNotFoundException($"Order con Id {orderId} no encontrado");
            }

            _orders.Remove(orderId);
        }

        public Order GetOrderById(int orderId)
        {
            if (!_orders.ContainsKey(orderId))
            {
                throw new KeyNotFoundException($"Order con Id {orderId} no encontrado");
            }

            return _orders[orderId];
        }
    }
}