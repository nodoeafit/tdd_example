using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderService.Test
{
    public class MenuServiceTest
    {

        [Fact]
        public void AddMenu_ShouldAddMenuToMenus()
        {
            // Arrange
            var menuService = new MenuService();
            var menu = new Menu { Id = 4, Name = "arepa" };
            // Act
            var result = menuService.AddMenu(menu);
            // Assert
            Assert.Contains(result, x => x.Name == "arepa");
        }


        [Fact]
        public void AddMenu_ShouldThrowException_WhenMenuIsNull()
        {
            // Arrange
            var menuService = new MenuService();
            Menu menu = null;
            // Act
            Action act = () => menuService.AddMenu(menu);
            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }


        [Fact]
        public void GetMenu_ShouldReturnMenu_WhenMenuExists()
        {
            // Arrange
            var menuService = new MenuService();
            // Act
            var result = menuService.GetMenu("sancocho");
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void GetMenu_ShouldReturnNull_WhenMenuDoesNotExist()
        {
            // Arrange
            var menuService = new MenuService();
            // Act
            var result = menuService.GetMenu("sancoch");
            // Assert
            Assert.Null(result);
        }
    }
}
