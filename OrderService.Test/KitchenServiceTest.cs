

public class KitchenServiceTest{
     
    [Fact]
    public void RegisterIngredients_ShouldAddIngredients()
    {
    // Arrange
    var kitchenService = new OrderService.KitchenService();

    // Act
    var items = kitchenService.RegisterIngredients(new List<string> { "Tomate", "Pasta" });

    // Assert
    Assert.Equal(2, items.Count);
    Assert.Contains("Tomate", items);
    Assert.Contains("Pasta", items);
    }

    [Fact]
    public void RegisterIngredients_ShouldThrowException_WhenListIsNull()
    {
        var kitchenService = new OrderService.KitchenService();

        Assert.Throws<ArgumentNullException>(() => kitchenService.RegisterIngredients(null));
    }


    [Fact]
public void ReceiveOrder_ShouldReduceIngredientQuantity()
{
    // Arrange
    var kitchenService = new OrderService.KitchenService();
    kitchenService.RegisterIngredients(new List<string> { "Tomate", "Pasta" });

    // Act
    kitchenService.ReceiveOrder(new List<string> { "Tomate", "Pasta" });

    // Assert
    var ingredients = kitchenService.GetIngredients();
    Assert.Equal(1, ingredients["Tomate"]); // Se usó 1 tomate
    Assert.Equal(1, ingredients["Pasta"]); // Se usó 1 pasta
}
    
}