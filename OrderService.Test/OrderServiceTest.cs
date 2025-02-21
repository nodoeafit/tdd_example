using Xunit;
using Moq;
using OrderService;

public class OrderServiceTest
{
    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderIsNull()
    {
        var service = new OrderService.OrderService();
        Assert.Throws<ArgumentNullException>(() => service.CreateOrder(null));
    }

    [Fact]
    public void CreateOrder_ShouldReturnOrderId()
    {
        var service = new OrderService.OrderService();
        var order = new Order { Id = 1, Amount = 20000 };
        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
    }

    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderAmountIsZero()
    {
        var service = new OrderService.OrderService();
        var order = new Order { Id = 1, Amount = 0 };
        Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
    }
    [Fact]
    public void CreateOrder_ShouldApplyPromotion_WhenOrderHasPromotion()
    {
        var service = new OrderService.OrderService();
        var order = new Order { Id = 3, Amount = 10000, HasPromotion = true };
        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
        Assert.Equal(9000, order.Amount);
    }

    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderAmountIsNegative()
    {
        var service = new OrderService.OrderService();
        var order = new Order { Id = 1, Amount = -1 };
        Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
    }


}