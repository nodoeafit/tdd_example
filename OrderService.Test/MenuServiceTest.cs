//prueba de items de menu
//Validar que la lista no sea nula o vacia
//Validar que la lista tenga al menos un item

using System;
using System.Runtime.CompilerServices;

public class MenuServiceTest
{

    [Fact]
    public void RegisterItems_ShouldAddDishes()
    {
        var menuService = new OrderService.MenuService();
        var dishNames = new List<string> { "Pescado", "Tarta", "Bandeja Paisa", "Mondongo" };

        // Act: Registrar los platos y obtener el menú
        menuService.RegisterItems(dishNames);
        var menuItems = menuService.GetMenu();

        // Assert: Verificar que se agregaron correctamente
        Assert.Equal(4, menuItems.Count);
        Assert.Contains(menuItems, item => item.Name == "Pescado");
        Assert.Contains(menuItems, item => item.Name == "Bandeja Paisa");
    }

    [Fact]
    public void RegisterItems_ShouldThrowException_WhenListIsNull()
    {
        var menuService = new OrderService.MenuService();
        Assert.Throws<ArgumentNullException>(() => menuService.RegisterItems(null));
    }

    [Fact]
    public void RegisterItems_ShouldThrowException_WhenListIsEmpty()
    {
        var menuService = new OrderService.MenuService();
        var emptyList = new List<string>();
        Assert.Throws<ArgumentException>(() => menuService.RegisterItems(emptyList));
    }


}