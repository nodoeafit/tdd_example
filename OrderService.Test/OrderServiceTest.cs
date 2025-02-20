using Xunit;
using Moq;
using OrderService;

public class OrderServiceTest 
{
    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderIsNull(){
        var service = new OrderService.OrderService();
        Assert.Throws<ArgumentNullException>(()=> service.CreateOrder(null));
    }

    [Fact]
    public void CreateOrder_ShouldReturnOrderId(){
        var service = new OrderService.OrderService();
        var order = new Order{ Id = 1, Amount = 20000 };
        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
    }

    [Fact]
    public void QueryAmountOrder_ShouldReturnOrderAmount() { 
        
        var service = new OrderService.OrderService();
        var order = new Order { Id = 1, Amount = 10000 };

        decimal amount = service.QueryAmount(order);
        
        Assert.Equal(order.Amount, amount);
    }

    [Fact]
    public void QueryAmountOrder_ShouldThrowException_WhenOrderIsNull()
    {
        var service = new OrderService.OrderService();
        Assert.Throws<ArgumentNullException>(() => service.QueryAmount(null));
    }

}