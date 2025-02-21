
namespace OrderService.Test {
    public class MenuServiceTest {
        [Fact]
        public void RegisterItems_ShouldReturnSameList_WhenValidListProvided() {
            // Arrange
            var service = new MenuService();
            var items = new List<string> { "Burger", "Fries" };

            // Act
            var result = service.RegisterItems(items);

            // Assert
            Assert.Equal(items, result);
        }

        [Fact]
        public void RegisterItems_ShouldThrowArgumentNullException_WhenNullListProvided() {
            // Arrange
            var service = new MenuService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.RegisterItems(null));
        }
    }
}
