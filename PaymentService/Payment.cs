namespace PaymentServiceNamespace
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string MetodoDePago { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public string NombreEnTarjeta { get; set; }
        public DateTime Vencimiento { get; set; }
        public string CVV { get; set; }
        public decimal DineroRecibido { get; set; }
    }
}