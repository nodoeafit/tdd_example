namespace MenuService
{
    public interface IMenuRepository
    {
        void AddMenuItem(MenuItem item);
        MenuItem GetMenuItemById(int id);
        List<MenuItem> GetMenu();
        void Save();


    }
}