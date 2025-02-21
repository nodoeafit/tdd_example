using Xunit;
using System;
using OrderService;
using static OrderService.Services.MenuService;
using OrderService.Services;

public class MenuServiceTest
{
    [Fact]
    public void GetMenu_ShouldThrowException_WhenDateIsInvalid()
    {
        var service = new MenuService();
        Assert.Throws<ArgumentException>(() => service.GetMenu(DateTime.MinValue));
    }

    [Fact]
    public void GetMenu_ShouldReturnMenu_WhenDateIsValid()
    {
        var service = new MenuService();
        var menu = service.GetMenu(DateTime.Today);
        Assert.NotNull(menu);
        Assert.NotEmpty(menu.Items); // Suponiendo que `Items` es una propiedad con los platos disponibles
    }
}
