using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class PaymentService
    {
        private List<Payment> payments;
        public PaymentService()
        {
            payments = new List<Payment>
                {
                    new Payment { Id =1, Name = "sancocho", Quantity = 1, PriceDish = 100 },
                    new Payment { Id =2, Name = "ajiaco", Quantity = 2, PriceDish = 200 },
                    new Payment { Id =3, Name = "mondongo", Quantity = 3, PriceDish = 300 }
                    };
        }
        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (Payment payment in payments)
            {
                total += payment.Quantity * payment.PriceDish;
            }
            return total;
        }
        public decimal ShowPriceDish(string name)
        {
            if (payments.Any(x => x.Name == name))
            {
                return payments.FirstOrDefault(x => x.Name == name).PriceDish;
            }
            else
            {
                return 0;
            }
        }
    }
}
