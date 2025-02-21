public class PaymentService
{
    public List<Item> RegisterItems(List<Item> items)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        if (items.Any(item => item == null))
            throw new ArgumentException("La lista contiene valores nulos");

        return items; 
    }

}
