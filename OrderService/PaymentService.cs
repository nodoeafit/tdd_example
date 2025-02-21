namespace OrderService
{
    public class PaymentService
    {
        private readonly IAuthService _authService; // Agrega el campo para el servicio de autenticación

        public PaymentService(IAuthService authService) // Constructor que recibe el servicio de autenticación
        {
            _authService = authService;
        }

        public bool ProcessPayment(Order order, decimal paymentAmount, string username, string password) // Agrega los parámetros para usuario y contraseña
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (paymentAmount <= 0)
            {
                throw new ArgumentException("El monto del pago debe ser mayor a cero.", nameof(paymentAmount));
            }

            if (paymentAmount < order.Amount)
            {
                throw new InvalidOperationException("El monto del pago es insuficiente.");
            }

            if (!_authService.IsAuthenticated(username, password)) // Verifica la autenticación
            {
                throw new UnauthorizedAccessException("El usuario no está autenticado.");
            }

            return true; // Si la autenticación pasa, el pago se simula como exitoso.
        }
    }
}