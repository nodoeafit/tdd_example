using OrderService;
public class PaymentServiceTests
    {
        private readonly PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _paymentService = new PaymentService(); 
        }

        [Fact]
        public void ProcessPayment_ShouldReturnTrue_WhenAmountIsSufficient()
        {
            // Arrange
            decimal customerBalance = 100.00m;
            decimal billAmount = 50.00m;

            // Act
            bool result = _paymentService.ProcessPayment(customerBalance, billAmount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ProcessPayment_ShouldReturnFalse_WhenBalanceIsInsufficient()
        {
            // Arrange
            decimal customerBalance = 30.00m;
            decimal billAmount = 50.00m;

            // Act
            bool result = _paymentService.ProcessPayment(customerBalance, billAmount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CalculateTotalWithTip_ShouldReturnCorrectAmount()
        {
            // Arrange
            decimal billAmount = 100.00m;
            decimal tipPercentage = 15.00m;

            // Act
            decimal totalWithTip = _paymentService.CalculateTotalWithTip(billAmount, tipPercentage);

            // Assert
            Assert.Equal(115.00m, totalWithTip);
        }

        [Fact]
        public void RefundPayment_ShouldIncreaseCustomerBalance()
        {
            // Arrange
            decimal customerBalance = 50.00m;
            decimal refundAmount = 20.00m;

            // Act
            decimal newBalance = _paymentService.RefundPayment(customerBalance, refundAmount);

            // Assert
            Assert.Equal(70.00m, newBalance);
        }

        [Fact]
        public void CalculateTotalWithTip_ShouldThrowException_WhenTipIsNegative()
        {
            // Arrange
            decimal billAmount = 100.00m;
            decimal tipPercentage = -10.00m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _paymentService.CalculateTotalWithTip(billAmount, tipPercentage));
        }
}