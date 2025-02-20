namespace OrderService {
    public class OrderService {
        public int CreateOrder (Order? order){
          if(order == null){
            throw new ArgumentNullException();
          }
          
          return order.Id;   
        }
    }
}