
namespace OrderService.Test {
    public class KitchenServiceTest {
        [Fact]
        public void RegisterItems_ShouldReturnSameList_WhenValidListProvided() {
            // Arrange
            var service = new KitchenService();
            var items = new List<string> { "Pizza", "Pasta" };

            // Act
            var result = service.RegisterItems(items);

            // Assert
            Assert.Equal(items, result);
        }

        [Fact]
        public void RegisterItems_ShouldThrowArgumentNullException_WhenNullListProvided() {
            // Arrange
            var service = new KitchenService();

            // Act & Assert
           List<string>? items = null;
           Assert.Throws<ArgumentNullException>(() => service.RegisterItems(items));
           }
    }
}
