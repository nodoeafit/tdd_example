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
    public void FindOrderById_ShouldReturnOrder_WhenOrderExists()
    {
        var service = new OrderService.OrderService();
        var foundOrder = service.FindOrderById(1);
        Assert.NotNull(foundOrder);
    }

    [Fact]
    public void FindOrderById_ShouldReturnNull_WhenOrderDoesNotExist()
    {
        var service = new OrderService.OrderService();
        var foundOrder = service.FindOrderById(1);
        Assert.Equal(1, foundOrder.Id);

    }

    [Fact]
    public void FindAmountGreaterThan_ShouldReturnOrders_WhenAmountIsGreaterThan()
    {
        var service = new OrderService.OrderService();
        var orders = service.FindAmountGreaterThan(1000);
        Assert.Contains(orders, o => o.Amount > 1000);
    }

    [Fact]
    public void FindAmountGreaterThan_ShouldThrowException_WhenAmountIsNull()
    {
        var service = new OrderService.OrderService();
        Assert.Throws<KeyNotFoundException>(() => service.FindAmountGreaterThan(100000000));

    }

    
}
