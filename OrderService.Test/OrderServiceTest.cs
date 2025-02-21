using Xunit;
using Moq;
using OrderService;
using System.Security.Cryptography;

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
        var order = new Order { 
            Id = 1, 
            Amount = 20000,
            Items = new List<Menu>{
                new Menu {Price = 20000}
            }
        };
        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
    }

    [Fact]
    public void CreateOrder_ShouldThrowException_WhenOrderAmountIsZero()
    {
        var service = new OrderService.OrderService();
        var order = new Order { 
            Id = 1, 
            Amount = 0,
            Items = new List<Menu>()
            };
        Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
    }

    [Fact]
    public void CreateOrder_ShouldApplyPromotion_WhenOrderHasPromotion()
    {
        var service = new OrderService.OrderService();
        var order = new Order
        {
            Id = 3,
            Amount = 10000,
            HasPromotion = true,
            Items = new List<OrderService.Menu>{
                new Menu {Price = 10000}
            }
            
            
            };


        var orderId = service.CreateOrder(order);
        Assert.Equal(order.Id, orderId);
        Assert.Equal(9000, order.Amount);
    }

    [Fact]
    public void CreateOder_ShouldThrowException_WhenOrderHasNoItems() {
        var service = new OrderService.OrderService();
        var order = new OrderService.Order {
            Id = 1,
            Amount = 10000,
            Items = new List<OrderService.Menu>()
        };

        Assert.Throws<ArgumentNullException>(() => service.CreateOrder(order));
    }

    [Fact]
    public void CreateOrder_ShouldCalculateTotalAmount() {
        var service = new OrderService.OrderService();
        var order = new OrderService.Order {
            Id = 2,
            Items = new List<OrderService.Menu> {
                new OrderService.Menu { Id = 1, Name = "Burger", Price = 100 },
                new OrderService.Menu { Id = 2, Name = "Pizza", Price = 200 }
            }
        };

        order.Amount = order.Items.Sum(item => item.Price);

        var orderId = service.CreateOrder(order);

        Assert.Equal(2, order.Items.Count);
        Assert.Equal(300, order.Amount);
    }
}