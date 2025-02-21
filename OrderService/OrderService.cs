namespace OrderService {
    public class OrderService {
        public int CreateOrder (Order? order){
          if(order == null){
            throw new ArgumentNullException();
          }

          if(order.Id <= 0){
            throw new ArgumentException("El id de la orden debe ser mayor a cero. Gracias.");
          }
          
          if(order.Amount <= 0){
            throw new ArgumentException("El monto de la orden debe ser mayor a cero. Gracias.");
          }

          if(order.Items == null || !order.Items.Any()){
            throw new ArgumentNullException("La lista de platos no puede estar vacia");
          }

          if(order.HasPromotion){
            order.Amount = order.Amount * 0.9m;
          }

          return order.Id;   
        }
    }
}