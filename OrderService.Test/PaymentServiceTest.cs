using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Test
{
    public class PaymentServiceTest
    {
        [Fact]
        public void CalculateTotalPrice_ShouldReturnTotalPrice_WhenExists()
        {
            // Arrange
            var paymentService = new PaymentService();
            // Act
            var result = paymentService.CalculateTotalPrice();
            // Assert
            Assert.NotNull(result);
        }
     
        [Fact]
        public void ShowPriceDish_ShouldReturnPriceDishForName_WhenExists()
        {
            // Arrange
            var paymentService = new PaymentService();
            // Act
            var result = paymentService.ShowPriceDish("sancocho");
            // Assert
            Assert.NotNull(result);
        }
    
    }
}
