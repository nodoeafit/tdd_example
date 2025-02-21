using OrderService.Models;
public class PaymentServiceTest
{

    [Fact]
    public void CreatePayment_ShouldReturnPaymentId()
    {

        var paymentService = new OrderService.Services.PaymentService();

        var payment = new Payment { Id = 1, OrderId = 1, CashPayment = 20000 };

        var paymentId = paymentService.CreatePayment(payment);

        Assert.Equal(payment.Id, paymentId);
    }

    [Fact]
    public void CreatePayment_ShouldThrowException_WhenPaymentIsNull()
    {

        var paymentService = new OrderService.Services.PaymentService();

        Assert.Throws<ArgumentNullException>(() => paymentService.CreatePayment(null));
    }

    [Fact]
    public void GetStatusPayment_ShouldReturnStatus()
    {

        var paymentService = new OrderService.Services.PaymentService();

        var payment = new Payment { Id = 1, OrderId = 1, CashPayment = 20000, Status = "Success" };

        var status = paymentService.GetStatusPayment(payment);

        Assert.Equal("Success", status);
    }

    [Fact]
    public void GetStatusPayment_ShouldThrowException_WhenPaymentIsNull()
    {
        var paymentService = new OrderService.Services.PaymentService();

        Assert.Throws<ArgumentNullException>(() => paymentService.GetStatusPayment(null));
    }

    [Fact]
    public void GetStatusPayment_ShouldThrowException_WhenPaymentIsFailed()
    {

        var paymentService = new OrderService.Services.PaymentService();

        var paymentFailed = new Payment { Id = 1, OrderId = 1, CashPayment = 20000, Status = "Failed" };

        Assert.Throws<InvalidOperationException>(() => paymentService.GetStatusPayment(paymentFailed));
    }
}