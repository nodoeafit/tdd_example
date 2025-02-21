

public class KitchenServiceTest{
     
    [Fact]
    public void RegisterIngredients_ShouldAddKitchen()
    {
        //Arrange
       var kitchenService = new OrderService.KitchenService();
        
        //Act
       var items = kitchenService.RegisterIngredients(new List<string> { "Arroz","Aguacate","Aceite","Azucar", "Sal"});
        
        //Assert
        Assert.Equal(5, items.Count());
        
    }
    [Fact]
    public void RegisterIngredients_ShouldThrowException_WhenListIsNull()
    {
        var kitchenService = new OrderService.KitchenService();

        Assert.Throws<ArgumentNullException>(() => kitchenService.RegisterIngredients(null));

    }
}