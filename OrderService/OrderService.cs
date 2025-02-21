namespace OrderService
{
    public class OrderService
    {
        public (int Id, decimal FinalAmount) CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (order.Amount <= 0)
            {
                throw new ArgumentException("El monto de la orden debe ser mayor a cero. Gracias.");
            }

            if (order.HasPromotion)
            {
                order.Amount *= 0.9m; // Aplica un 10% de descuento
            }

            return (order.Id, order.Amount);
        }
    }
}
