namespace MenuService.Tests
{
    public class MenuServiceTest
    {
        menuService = new MenuService();

        [Fact]
        // Obtiene el menu si no esta vacio
        public void GetMenu_ShouldReturnNonNullMenu()
        {
            var result = menuService.GetMenu();
            Assert.NotNull(result);
        }

        [Fact]
        // Obtiene el precio correcto de un producto
        public void GetPrice_ShouldReturnCorrectPrice()
        {
            var result = menuService.GetPrice("Hamburguesa");
            Assert.Equal(5.99m, result);
        }

        [Fact]
        // Si el precio no existe porque el item es invalido
        public void GetPrice_ShouldThrowExceptionForInvalidItem()
        {
            Assert.Throws<InvalidOperationException>(() => menuService.GetPrice("Invalido"));
        }

        [Fact]
        // Agrega un nuevo item al menu
        public void AddMenuItem_ShouldAddNewItem()
        {
            menuService.AddMenuItem("Ensalada", 4.99m);
            var result = menuService.GetPrice("Ensalada");
            Assert.Equal(4.99m, result);
        }

        [Fact]
        // Elimina un item del menu
        public void RemoveMenuItem_ShouldRemoveItem()
        {
            menuService.RemoveMenuItem("Hamburguesa");
            Assert.Throws<KeyNotFoundException>(() => menuService.GetPrice("Hamburguesa"));
        }

        [Fact]
        // Actualiza el precio de un item existente
        public void UpdateMenuItemPrice_ShouldUpdatePrice()
        {
            menuService.UpdateMenuItemPrice("Hamburguesa", 6.99m);
            var result = menuService.GetPrice("Hamburguesa");
            Assert.Equal(6.99m, result);
        }

        [Fact]
        // Obtiene todos los items del menu
        public void GetMenu_ShouldReturnAllMenuItems()
        {
            var result = menuService.GetMenu();
            Assert.Equal(3, result.Count); // Suponiendo que hay 3 items en el menu
        }
    }
}
