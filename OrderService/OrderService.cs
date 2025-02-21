namespace OrderService
{
  public class OrderService
  {

    public int CreateOrder(Order? order)
    {
      if (order == null)
      {
        throw new ArgumentNullException();
      }

      if (order.Amount <= 0)
      {
        throw new ArgumentException("El monto de la orden debe ser mayor a cero. Gracias.");
      }

      if (order.HasPromotion)
      {
        order.Amount = order.Amount * 0.9m;
      }


      return order.Id;



    }
  }
}