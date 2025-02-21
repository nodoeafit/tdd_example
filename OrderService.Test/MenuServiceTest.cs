using OrderService.Models;

public class MenuServiceTest
{

    [Fact]
    public void RegisterItems_ShouldAddDishes()
    {
        var menuService = new OrderService.Services.MenuService();

        var items = menuService.RegisterItems(new List<string> { "Pescado", "Tarta", "Bandeja Paisa", "Mondongo" });

        Assert.Equal(4, items.Count());
        Assert.Equal("Pescado", items[0]);
        Assert.Equal("Tarta", items[1]);
        Assert.Equal("Bandeja Paisa", items[2]);
        Assert.Equal("Mondongo", items[3]);

    }

    [Fact]
    public void RegisterItems_ShouldThrowException_WhenListIsNull()
    {
        var menuService = new OrderService.Services.MenuService();

        Assert.Throws<ArgumentNullException>(() => menuService.RegisterItems(null));
    }

    [Fact]
    public void GetAllItems_ShouldReturnAllItems(){

        var menuService = new OrderService.Services.MenuService();

        var itemsListExist = new List<string> { "Pescado", "Tarta", "Bandeja Paisa", "Mondongo" };

        menuService.RegisterItems(itemsListExist);

        var items = menuService.GetAllItems(itemsListExist);

        Assert.Equal(4, items.Count());
    }

    [Fact]
    public void GetAllItems_ShouldThrowException_WhenListIsNull(){

        var menuService = new OrderService.Services.MenuService();

        Assert.Throws<ArgumentNullException>(()=> menuService.GetAllItems(null));
    }

    [Fact]
    public void UpdateItem_ShouldUpdateItem_WhenItemExists(){

        var menuService = new OrderService.Services.MenuService();

        var updateItem = new Menu { Id = 1, ItemName = "Pescado" };

        menuService.RegisterItems(new List<string> { updateItem.ItemName });

        var item = menuService.UpdateItemName(1, "Pescado Frito");

        Assert.Equal("Pescado Frito", item.ItemName);
    }

    [Fact]
    public void UpdateItem_ShouldThrowException_WhenItemDoesNotExist(){

        var menuService = new OrderService.Services.MenuService();

        Assert.Throws<NotImplementedException>(()=> menuService.UpdateItemName(5, "Pescado Frito"));
    }
}