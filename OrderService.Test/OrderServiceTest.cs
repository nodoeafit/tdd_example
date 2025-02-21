namespace OrderService.Test
{
    using Xunit;
    using OrderServiceNamespace;

    public class OrderServiceTest
    {
        [Fact]
        public void CreateOrder_ShouldThrowException_WhenOrderIsNull()
        {
            var service = new OrderService();
            Assert.Throws<ArgumentNullException>(() => service.CreateOrder(null));
        }

        [Fact]
        public void CreateOrder_ShouldReturnOrderId()
        {
            var service = new OrderService();
            var order = new Order { Id = 1, Amount = 20000 };
            var orderId = service.CreateOrder(order);
            Assert.Equal(order.Id, orderId);
            Assert.True(order.IsProcessed);
        }

    }
}
