namespace OrderService
{
     public class PaymentService
    {
        public bool ProcessPayment(decimal customerBalance, decimal billAmount)
        {
            return customerBalance >= billAmount;
        }

        public decimal CalculateTotalWithTip(decimal billAmount, decimal tipPercentage)
        {
            if (tipPercentage < 0)
                throw new ArgumentException("La propina no puede ser negativa.");
            
            return billAmount + (billAmount * tipPercentage / 100);
        }

        public decimal RefundPayment(decimal customerBalance, decimal refundAmount)
        {
            return customerBalance + refundAmount;
        }
    }
}