namespace OrderService.Models {
    public class Order {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool HasPromotion { get; set; }
    }
}