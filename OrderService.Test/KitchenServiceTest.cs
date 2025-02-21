using OrderService;
// using KitchenService;

public class KitchenServiceTest
{

    [Fact]
    public void OrderReady_ShouldUpdateOrderInKitchen()
    {
        var kitchenService = new KitchenService();
        var order = new Order { Id = 1, Amount = 20000, HasPromotion = false };

        kitchenService.ReceiveOrder(order);
        kitchenService.OrderReady(order.Id);
        // Assert.NotNull(kitchenService.GetOrder(order.Id))
        Assert.True(kitchenService.GetOrder(order.Id).IsReady);
    }

    [Fact]
    public void GetOrde_ShouldAddOrderInKitchen()
    {
        var kitchenService = new KitchenService();
        var order = new Order { Id = 1, Amount = 20000, HasPromotion = false };
        kitchenService.ReceiveOrder(order);

        Assert.Equal(kitchenService.GetOrder(order.Id), 1);

    }



    [Fact]
    public void RegisterIngredients_ShouldAddKitchen()
    {

        var kitchenService = new OrderService.KitchenService();


        var items = kitchenService.RegisterIngredients(new List<string> { "Arroz", "Aguacate", "Aceite", "Azucar", "Sal" });


        Assert.Equal(5, items.Count());

    }
    [Fact]
    public void RegisterIngredients_ShouldThrowException_WhenListIsNull()
    {
        var kitchenService = new OrderService.KitchenService();

        Assert.Throws<ArgumentNullException>(() => kitchenService.RegisterIngredients(null));

    }


}