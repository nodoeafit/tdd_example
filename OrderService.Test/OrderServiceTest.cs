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
    public void GetOrderById_ShouldThrowException_WhenOrderDoesNotExist(){
        var service = new OrderService.OrderService();
        Assert.Throws<KeyNotFoundException>(()=> service.GetOrderById(4));
    }

    [Fact]
    public void GetOrderById_ShouldReturnOrder_WhenOrderIdExists(){
        var service = new OrderService.OrderService();
        var orderExist = new Order{ Id = 1, Amount = 20000 };
        service.CreateOrder(orderExist);
        var result = service.GetOrderById(orderExist.Id);
        Assert.Equal(orderExist.Id, result.Id);
        Assert.Equal(orderExist.Amount, result.Amount);
    }
}