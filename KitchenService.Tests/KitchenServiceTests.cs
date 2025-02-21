namespace KitchenServiceNamespace.Tests
{
    using Xunit;
    using KitchenServiceNamespace;

    public class KitchenServiceTests
    {
        [Fact]
        public void PrepareDish_ShouldSetDishReady()
        {
            var service = new KitchenService();
            service.PrepareDish();
            Assert.True(service.IsDishReady);
        }

        [Fact]
        public void CorrectDish_ShouldDishNotReady()
        {
            var service = new KitchenService();
            service.PrepareDish();
            service.CorrectDish();
            Assert.False(service.IsDishReady);
        }
    }
}