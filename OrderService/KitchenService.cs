using System;
namespace OrderService
{
    public class KitchenService
    {
        public List<Order> _ordersInKitchen = new List<Order>();
        public List<string> RegisterIngredients(List<string>? items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }
            return items;
        }

        public void ReceiveOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException();
            }
            _ordersInKitchen.Add(order);
        }

        public Order? GetOrder(int orderId)
        {
            return _ordersInKitchen.FirstOrDefault(x => x.Id == orderId);
        }

        public void OrderReady(int orderId)
        {
            var order = GetOrder(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }
            order.IsReady = true;
        }

    }

}