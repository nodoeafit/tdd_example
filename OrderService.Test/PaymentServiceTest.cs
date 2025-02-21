using Moq;
using Xunit;
using OrderService;
using System;

public class PaymentServiceTest
{
    [Fact]
    public void ProcessPayment_ShouldReturnTrue_WhenPaymentIsSufficient()
    {
        // Arrange
        var order = new Order { Id = 1, Amount = 100 };
        decimal paymentAmount = 100;
        var mockAuthService = new Mock<IAuthService>(); // Mock del servicio de autenticación
        mockAuthService.Setup(x => x.IsAuthenticated(It.IsAny<string>(), It.IsAny<string>())).Returns(true); // Simula usuario autenticado (cualquier usuario/contraseña)
        var paymentService = new PaymentService(mockAuthService.Object); // Inyecta el mock

        // Act
        bool paymentSuccessful = paymentService.ProcessPayment(order, paymentAmount, "testuser", "password"); // Pasar usuario y contraseña (aunque el mock los ignora)

        // Assert
        Assert.True(paymentSuccessful);
    }

    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenOrderIsNull()
    {
        var mockAuthService = new Mock<IAuthService>();
        mockAuthService.Setup(x => x.IsAuthenticated(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        var paymentService = new PaymentService(mockAuthService.Object);

        Assert.Throws<ArgumentNullException>(() => paymentService.ProcessPayment(It.IsAny<Order>(), 100, "testuser", "password"));
    }

    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenPaymentAmountIsZero()
    {
        var order = new Order { Id = 1, Amount = 100 };
        var mockAuthService = new Mock<IAuthService>();
        mockAuthService.Setup(x => x.IsAuthenticated(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        var paymentService = new PaymentService(mockAuthService.Object);

        Assert.Throws<ArgumentException>(() => paymentService.ProcessPayment(order, 0, "testuser", "password"));
    }

    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenPaymentAmountIsInsufficient()
    {
        var order = new Order { Id = 1, Amount = 100 };
        decimal paymentAmount = 50;
        var mockAuthService = new Mock<IAuthService>();
        mockAuthService.Setup(x => x.IsAuthenticated(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        var paymentService = new PaymentService(mockAuthService.Object);

        Assert.Throws<InvalidOperationException>(() => paymentService.ProcessPayment(order, paymentAmount, "testuser", "password"));
    }

    [Fact]
    public void ProcessPayment_ShouldThrowException_WhenUserIsNotAuthenticated()
    {
        // Arrange
        var order = new Order { Id = 1, Amount = 100 };
        decimal paymentAmount = 100;
        string username = "testuser";
        string password = "wrongpassword";

        var mockAuthService = new Mock<IAuthService>();
        mockAuthService.Setup(x => x.IsAuthenticated(username, password)).Returns(false); // Simula usuario NO autenticado

        var paymentService = new PaymentService(mockAuthService.Object);

        // Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => paymentService.ProcessPayment(order, paymentAmount, username, password));
    }
}