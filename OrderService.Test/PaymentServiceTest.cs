using Xunit;

namespace OrderService.Test
{
    public class PaymentServiceTest
    {
        [Fact]
        public void RegisterItems_ShouldReturnSameList_WhenValidListProvided()
        {
            var service = new PaymentService();
            var items = new List<Item>
    {
        new Item { Id = 1, Price = 100 },
        new Item { Id = 2, Price = 200 }
    };

            var result = service.RegisterItems(items);

            Assert.Equal(items, result); 
        }

        [Fact]
        public void RegisterItems_ShouldThrowArgumentNullException_WhenNullListProvided()
        {
            var service = new PaymentService();

            Assert.Throws<ArgumentNullException>(() => service.RegisterItems(null!)); 
        }

        [Fact]
        public void RegisterItems_ShouldReturnEmptyList_WhenEmptyListProvided()
        {
            var service = new PaymentService();
            var items = new List<Item>(); // Lista vacía

            var result = service.RegisterItems(items);

            Assert.Empty(result); 
            }

        [Fact]
        public void RegisterItems_ShouldThrowException_WhenListContainsNullValues()
        {
            var service = new PaymentService();
            var items = new List<Item?> // Permite valores nulos
    {
        new Item { Id = 1, Price = 100 },
        null 
    };

            Assert.Throws<ArgumentException>(() => service.RegisterItems(items!));
        }
    }
}