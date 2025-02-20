namespace OrderService {
    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>
            {
                new Order { Id = 1, Amount = 20000 },
                new Order { Id = 2, Amount = 10000 },
                new Order { Id = 3, Amount = 50000 }
            };
        }

        public int CreateOrder(Order? order)
        {
            if (order == null)
            {
                throw new ArgumentNullException();
            }

            return order.Id;
        }

        public Order? FindOrderById(int id)
        {

            var order = orders.Find(o => o.Id == id);
            if (order == null)
            {
                throw new KeyNotFoundException("No se encontró ninguna orden con ese ID.");
            }

            return order;
        }

        public List<Order> FindAmountGreaterThan(decimal amount)
        {
            var order = orders.Where(o => o.Amount > amount).ToList();
            if (order == null || !order.Any())
            {
                throw new KeyNotFoundException();
            }
            return order;
        }
    }

}