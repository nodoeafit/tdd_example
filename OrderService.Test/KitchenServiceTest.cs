using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Test
{
    public class KitchenServiceTest
    {
        [Fact]
        public void getListOfIngredients_ShouldReturnIngredients_WhenExists()
        {
            // Arrange
            var kitchenService = new KitchenService();
            // Act
            var result = kitchenService.getListOfIngredients();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void getListOfIngredients_ShouldReturnNull_WhenDoesNotExist()
        {
            // Arrange
            var kitchenService = new KitchenService();
            // Act
            var result = kitchenService.getListOfIngredients();
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public void FindIngredientsEgualsZero_ShouldReturnIngredients_WhenQuantityEqualZero()
        {
            // Arrange
            var kitchenService = new KitchenService();
            // Act
            var result = kitchenService.FindIngredientsEgualsZero();
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void FindIngredientsEgualsZero_ShouldReturnEmpy_WhenQuantityDoesNotEqualZero()
        {
            // Arrange
            var kitchenService = new KitchenService();
            // Act
            var result = kitchenService.FindIngredientsEgualsZero();
            // Assert
            Assert.Empty(result);
        }

    }
}