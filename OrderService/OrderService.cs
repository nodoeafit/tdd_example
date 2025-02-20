namespace OrderService {
    public class OrderService {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public int CreateOrder (Order? order){
          if(order == null){
            throw new ArgumentNullException();
          }

            if (order.Amount < 0)
            {
                throw new ArgumentException("El valor no puede ser negativo.");
            }
          
          _repository.Save(order);
          return order.Id;   
        }
    }
}