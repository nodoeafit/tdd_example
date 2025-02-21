namespace OrderServiceNamespace
{
    public class OrderService
    {
        public int CreateOrder(Order? order)
        {
            if (order == null) throw new ArgumentNullException();
            if (order.Amount <= 0) throw new ArgumentException("El monto de la orden debe ser mayor a cero.");
            order.IsProcessed = true;
            return order.Id;
        }
    }
}