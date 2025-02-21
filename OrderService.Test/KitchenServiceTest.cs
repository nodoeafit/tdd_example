using OrderService.Models;

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

    [Fact]
    public void DeleteIngredient_ShouldDeleteIngredient(){

        var kitchenService = new OrderService.Services.KitchenService();

        var deleteItem = new Kitchen { Id = 1, IngredientName = "Arroz" };

        kitchenService.RegisterIngredients(new List<string> { deleteItem.IngredientName });

        var result = kitchenService.DeleteIngredient(1);
        
        Assert.Equal("Ingredient deleted", result.IngredientName);
    }

    [Fact]
    public void DeleteIngredient_ShouldThrowException_WhenIdDoesNotExist(){

        var kitchenService = new OrderService.Services.KitchenService();
        
        Assert.Throws<NotImplementedException>(()=> kitchenService.DeleteIngredient(5));
    }
}