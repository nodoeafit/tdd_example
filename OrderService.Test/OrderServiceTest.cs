using Xunit;
using Moq;
using OrderService;

public class OrderServiceTest 
{
    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderIsNull(){
        var mockRepo = new Mock<IOrderRepository>();
        var service = new OrderService.OrderService(mockRepo.Object);

        Assert.Throws<ArgumentNullException>(()=> service.CreateOrder(null));
    }

    [Fact]
    public void CreateOrder_ShouldReturnOrderId(){
        var mockRepo = new Mock<IOrderRepository>();
        var service = new OrderService.OrderService(mockRepo.Object);
        var order = new Order{ Id = 1, Amount = 20000 };
        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
    }
    [Fact]
    public void CreateOrder_ShouldCallRepositorySaveMethod() {
        var mockRepo = new Mock<IOrderRepository>();
        var service = new OrderService.OrderService(mockRepo.Object);
        var order = new Order { Id = 1, Amount = 20000 };

        service.CreateOrder(order);

        mockRepo.Verify(repo => repo.Save(order), Times.Once);
    }
    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderAmountIsNegative()
    {
        var mockRepo = new Mock<IOrderRepository>();
        var service = new OrderService.OrderService(mockRepo.Object);
        var invalidOrder = new Order { Id = 1, Amount = -10000 };

        Assert.Throws<ArgumentException>(() => service.CreateOrder(invalidOrder));
    }
}