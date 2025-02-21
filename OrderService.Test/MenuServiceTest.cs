public class MenuServiceTest
{

    [Fact]
    public void RegisterItems_ShouldAddDishes()
    {
        var menuService = new OrderService.Services.MenuService();

        var items = menuService.RegisterItems(new List<string> { "Pescado", "Tarta", "Bandeja Paisa", "Mondongo" });

        Assert.Equal(4, items.Count());

    }

    [Fact]
    public void RegisterItems_ShouldThrowException_WhenListIsNull()
    {
        var menuService = new OrderService.Services.MenuService();

        Assert.Throws<ArgumentNullException>(() => menuService.RegisterItems(null));

    }
}