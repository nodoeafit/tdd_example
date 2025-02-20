
namespace OrderService {
    public class OrderService {
        public int CreateOrder (Order? order){
          if(order == null){
            throw new ArgumentNullException();
          }
          
          return order.Id;   
        }

        // M�todo para consultar el monto de la orden
        public decimal QueryAmount(Order? order)
        {
            // Si la orden es v�lida, devolvemos el monto
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "La orden no puede ser nula.");
            }

            return order.Amount;
        }
    }
}