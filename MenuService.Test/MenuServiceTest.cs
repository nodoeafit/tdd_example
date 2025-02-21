using Xunit;
using Moq;
using System.Collections.Generic;

namespace MenuService.Test
{
    public class MenuServiceTests
    {
        private Mock<IMenuRepository> _mockMenuRepository;
        private MenuService _menuService;

        public MenuServiceTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _menuService = new MenuService(_mockMenuRepository.Object);
        }

        [Fact]
        public void AddMenuItem_ShouldCallRepositorySaveMethod()
        {
            var mockRepo = new Mock<IMenuRepository>();
            var service = new MenuService(mockRepo.Object);
            var menuItem = new MenuItem  (1, "Pizza", 12000);

            service.AddMenuItem(menuItem);

            mockRepo.Verify(repo => repo.AddMenuItem(menuItem), Times.Once);
            mockRepo.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void GetMenu_ShouldReturnAllMenuItems()
        {
            
            var expectedMenuItems = new List<MenuItem>
    {
        new MenuItem ( 1, "Pizza", 12000),
        new MenuItem ( 2, "Pasta", 18000)
    };

            _mockMenuRepository.Setup(repo => repo.GetMenu()).Returns(expectedMenuItems);

            var actualMenuItems = _menuService.GetMenuItems();

            Assert.Collection(actualMenuItems,
               item1 =>
               {
                   Assert.Equal(1, item1.Id);
                   Assert.Equal("Pizza", item1.Name);
                   Assert.Equal(12000, item1.Price); // Se corrigió el valor esperado
               },
               item2 =>
               {
                   Assert.Equal(2, item2.Id);
                   Assert.Equal("Pasta", item2.Name);
                   Assert.Equal(18000, item2.Price); // Se corrigió el valor esperado
               }
   );
        }
    }
}
