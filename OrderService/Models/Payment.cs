namespace OrderService.Models {
    public class Payment {
        public int Id { get; set; }
        public decimal OrderId { get; set; }
        public Order? Order { get; set; }    
        public decimal CashPayment { get; set; }
        public string? Status { get; set; }
    }
}