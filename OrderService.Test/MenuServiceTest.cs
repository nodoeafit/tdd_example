//prueba de items de menu
//Validar que la lista no sea nula o vacia
//Validar que la lista tenga al menos un item

using System;
using System.Runtime.CompilerServices;

public class MenuServiceTest {

    [Fact]
    public void RegisterItems_ShouldAddDishes()
    {
        //Arrange
        var menuService = new OrderService.MenuService();
        
        //Act
       var items = menuService.RegisterItems(new List<string> { "Pescado","Tarta","Bandeja Paisa","Mondongo"});
        
        //Assert
        Assert.Equal(4, items.Count());
        
    }
    [Fact]
    public void RegisterItems_ShouldThrowException_WhenListIsNull()
    {
        var menuService = new OrderService.MenuService();

        Assert.Throws<ArgumentNullException>(() => menuService.RegisterItems(null));

    }
    

}