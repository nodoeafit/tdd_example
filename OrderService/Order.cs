namespace OrderService {
    public class Order {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool HasPromotion { get; set; }


        public List<Menu> Items {get; set;} = new List<Menu>();
    }
}