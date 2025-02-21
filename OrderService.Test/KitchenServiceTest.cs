public class KitchenServiceTest{
     
    [Fact]
    public void RegisterIngredients_ShouldAddKitchen()
    {
       var kitchenService = new OrderService.Services.KitchenService();

       var items = kitchenService.RegisterIngredients(new List<string> { "Arroz","Aguacate","Aceite","Azucar", "Sal"});

        Assert.Equal(5, items.Count());
        
    }

    [Fact]
    public void RegisterIngredients_ShouldThrowException_WhenListIsNull()
    {
        var kitchenService = new OrderService.Services.KitchenService();

        Assert.Throws<ArgumentNullException>(() => kitchenService.RegisterIngredients(null));
    }
}