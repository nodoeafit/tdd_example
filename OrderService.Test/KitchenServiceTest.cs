using system

public class KitchenServiceTest
{
    [Fact]
    public void GenerarFactura_ShouldSetMontoAndMetodoPago_WhenValidInput()
    {
        // Arrange
        var paymentService = new Payment_services();
        // Act
        paymentService.GenerarFactura(100, "Tarjeta");
        // Assert
        Assert.Equal(100, paymentService.MontoTotal);
        Assert.Equal("Tarjeta", paymentService.MetodoPago);
    }
 
    [Fact]
    public void GenerarFactura_ShouldThrowArgumentException_WhenMontoIsLessThanOrEqualToZero()
    {
        // Arrange
        var paymentService = new Payment_services();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => paymentService.GenerarFactura(0, "Tarjeta"));
        Assert.Throws<ArgumentException>(() => paymentService.GenerarFactura(-50, "Tarjeta"));
    }
 
    [Fact]
    public void ProcesarPago_ShouldReturnTrue_WhenValidPayment()
    {
        // Arrange
        var paymentService = new Payment_services();
        paymentService.GenerarFactura(100, "Tarjeta");
        // Act
        var result = paymentService.ProcesarPago();
        // Assert
        Assert.True(result);
    }
 
    [Fact]
    public void ProcesarPago_ShouldReturnFalse_WhenInvalidPayment()
    {
        // Arrange
        var paymentService = new Payment_services();
        // Act
        var result = paymentService.ProcesarPago();
        // Assert
        Assert.False(result);
    }
    [Fact]

}