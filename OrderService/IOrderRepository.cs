namespace OrderService
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}