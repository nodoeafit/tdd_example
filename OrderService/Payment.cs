namespace OrderService
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
    }
}