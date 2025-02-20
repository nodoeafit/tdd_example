using OrderService.Models;

namespace OrderService.Services {
    public class OrderService {
        public int CreateOrder (Order? order){
          if(order == null){
            throw new ArgumentNullException();
          }
          
          return order.Id;   
        }

        public Order GetOrderById (int id){

        if(id == 1){
          return new Order{ Id = 1, Amount = 20000 };
        }

          throw new KeyNotFoundException();
        }
        
    }
}