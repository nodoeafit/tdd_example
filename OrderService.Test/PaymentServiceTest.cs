using System;
using OrderService;

public class PaymentServiceTest
{
    [Fact]
    public void ProcessPayment_ShouldProcessSuccessfully_WhenValidPayment()
    {
        var paymentService = new PaymentService();
        var payment = new Payment { Id = 1, Amount = 50000, OrderId = 1 };
        
        var transactionId = paymentService.ProcessPayment(payment);
        
        Assert.Equal(payment.Id, transactionId);
    }

    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenPaymentIsInvalid()
    {
        var paymentService = new PaymentService();
        
        Assert.Throws<ArgumentNullException>(() => paymentService.ProcessPayment(null));
        
        var invalidPayment = new Payment { Id = 2, Amount = 0, OrderId = 2 };
        Assert.Throws<ArgumentException>(() => paymentService.ProcessPayment(invalidPayment));
    }
}