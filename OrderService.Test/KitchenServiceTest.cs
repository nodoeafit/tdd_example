

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

    [Fact]
    public void RegisterIngredients_ShouldHandleDuplicateIngredients(){
        //Arrange
        var kitchenService = new OrderService.KitchenService();
        var ingredients = new List<string> { "Arroz","Arroz","Aceite","Azucar","Pollo" ,"Sal","Tomates","Lechuga","Tomates","Pollo"};

        //Act
        var items = kitchenService.RegisterIngredients(ingredients);

        //Assert
        Assert.Equal(10, items.Count());
        Assert.Equal(2, items.Count(x => x == "Arroz"));
        Assert.Equal(2, items.Count(x => x == "Tomates"));
        Assert.Equal(2, items.Count(x => x == "Pollo"));
    }
}