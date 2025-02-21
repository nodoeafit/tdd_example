namespace KitchenService.Test;

public class KitchenServiceTest
{
    [Fact]
    public void Should_ProcessOrderSuccessfully()
    {
        
        var kitchenService = new KitchenService();
        var orderId = 1;

       
        var result = kitchenService.ProcessOrder(orderId);

        
        Assert.True(result, "The order should be processed successfully.");
    }
}
