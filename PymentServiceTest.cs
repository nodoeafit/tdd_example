using Xunit;
using OrderService;
using System;

public class PaymentServiceTest
{
    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenAmountIsZeroOrNegative()
    {
        // Arrange
        var paymentService = new PaymentService();

        // Act
        Action actWithZero = () => paymentService.ProcessPayment(0);

        // Assert
        Assert.Throws<ArgumentException>(actWithZero);

        // Act
        Action actWithNegative = () => paymentService.ProcessPayment(-100);

        // Assert
        Assert.Throws<ArgumentException>(actWithNegative);
    }

    [Fact]
    public void IsPaymentSuccessful_ShouldReturnTrue_WhenTransactionIdIsValid()
    {
        // Arrange
        var paymentService = new PaymentService();

        // Act
        var result = paymentService.IsPaymentSuccessful("David1234");  

        // Assert
        Assert.True(result);  
    }

    [Fact]
    public void IsPaymentSuccessful_ShouldThrowException_WhenTransactionIdIsNullOrEmpty()
    {
        // Arrange
        var paymentService = new PaymentService();

        // Act
        Action actWithNull = () => paymentService.IsPaymentSuccessful(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(actWithNull);

        // Act
        Action actWithEmpty = () => paymentService.IsPaymentSuccessful("");

        // Assert
        Assert.Throws<ArgumentNullException>(actWithEmpty);
    }
}
