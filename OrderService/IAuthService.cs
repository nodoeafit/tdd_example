namespace OrderService
{
    public interface IAuthService
    {
        bool IsAuthenticated(string username, string password);
    }
}